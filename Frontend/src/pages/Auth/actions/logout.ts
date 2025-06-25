"use server";

import { deleteSession } from "@/shared/lib/auth";
import { redirect } from "next/navigation";

export async function logout() {
  await deleteSession();
  redirect("/login");
} 