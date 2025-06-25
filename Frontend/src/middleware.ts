import { NextResponse } from "next/server";
import type { NextRequest } from "next/server";
import { getSession } from "@/shared/lib/auth";
import { getUserFromToken } from "./shared/utils/getUserFromToken";

export async function middleware(request: NextRequest) {
  const token = await getSession();
  const user = await getUserFromToken(token);

  // Публічні роути
  const publicRoutes = [
    "/login",
    "/register",
    "/api/auth/login",
    "/lesson",
    "/api/lessons",
    "/images", // Додаємо доступ до зображень
    "/", // головна сторінка
  ];

  // Перевіряємо чи це публічний роут
  const isPublicRoute = publicRoutes.some(
    (route) =>
      request.nextUrl.pathname === route ||
      request.nextUrl.pathname.startsWith(route + "/")
  );

  if (isPublicRoute) {
    return NextResponse.next();
  }

  // Захищені роути (тести та інші)
  if (!user) {
    const returnUrl = encodeURIComponent(request.nextUrl.pathname);
    return NextResponse.redirect(
      new URL(`/login?returnUrl=${returnUrl}`, request.url)
    );
  }

  if (
    request.nextUrl.pathname.startsWith("/test/") &&
    (user.role === "teacher" || user.role === "admin")
  ) {
    // Витягуємо всі числові параметри з шляху
    const match = request.nextUrl.pathname.match(/^\/test\/((?:\d+\/)*\d+)/);
    const testParams = match ? match[1] : null;
    if (testParams) {
      return NextResponse.redirect(
        new URL(`/test/edit/${testParams}`, request.url)
      );
    }
  }

  return NextResponse.next();
}

export const config = {
  matcher: [
    /*
     * Match all request paths except for the ones starting with:
     * - _next/static (static files)
     * - _next/image (image optimization files)
     * - favicon.ico (favicon file)
     * - public folder
     * - images folder
     */
    "/((?!_next/static|_next/image|favicon.ico|public|images).*)",
  ],
};
