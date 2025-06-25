"use client";

import type { UserDecoded } from "@/shared/types/auth";
import Link from "next/link";
import { logout } from "@/pages/Auth/actions/logout";

interface UserProps {
  user: UserDecoded;
}

export function User({ user }: UserProps) {

  const handleLogout = async () => {
    await logout();
  };

  return (
    <div className="flex items-stretch gap-4">
      {user.role === "teacher" && (
        <Link
          href="/student/add"
          className="
  cursor-pointer
  text-center
  weight-bold
  px-6
  py-3
  bg-white
  text-slate-800
  rounded-xl
  shadow-md
  font-semibold
  hover:bg-slate-200
  hover:shadow-lg
  focus:outline-none
  focus:ring-2
  focus:ring-slate-400
  transition
  duration-150
  ease-in-out
  active:scale-95
"
        >
          Додати студента
        </Link>
      )}
      <button
        onClick={handleLogout}
        className="
          cursor-pointer
          text-center
          weight-bold
          px-6
          py-3
          bg-red-600
          text-white
          rounded-xl
          shadow-md
          font-semibold
          hover:bg-red-700
          hover:shadow-lg
          focus:outline-none
          focus:ring-2
          focus:ring-red-400
          transition
          duration-150
          ease-in-out
          active:scale-95
        "
      >
        Вийти
      </button>
    </div>
  );
}
