import { jwtDecode } from "jwt-decode";
import type { User, UserDecoded } from "../types/auth";
import roles from "../config/roles";

export async function getUserFromToken(
  token: string | null
): Promise<UserDecoded | null> {
  if (!token) return null;

  try {
    const decoded = jwtDecode(token) as User;
    const role =
      decoded["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];
    return {
      ...decoded,
      role: roles[role] as "student" | "teacher" | "admin",
      schoolId: decoded["SchoolId"]
    };
  } catch {
    return null;
  }
}
