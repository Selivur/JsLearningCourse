"use server";
import { cookies } from "next/headers";

export async function createSession(token: string): Promise<string> {
  const expires = new Date(Date.now() + 24 * 60 * 60 * 1000); // 24 hours

  (await cookies()).set("session", token, {
    httpOnly: true,
    secure: process.env.NODE_ENV === "production",
    sameSite: "lax",
    expires,
  });

  return token;
}

export async function getSession(): Promise<string | null> {
  const session = (await cookies()).get("session");

  return session?.value || null;
}

export async function deleteSession() {
  (await cookies()).delete("session");
}
