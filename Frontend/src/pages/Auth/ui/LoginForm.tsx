"use client";

import { useActionState } from "react";
import { useSearchParams } from "next/navigation";
import { signin } from "@/pages/Auth/actions/auth";

export default function LoginForm() {
  const searchParams = useSearchParams();
  const returnUrl = searchParams?.get("returnUrl");
  const [state, action, pending] = useActionState(signin, undefined);

  return (
    <div className="max-w-md mx-auto mt-8 p-6 bg-white rounded-lg shadow-md">
      <h2 className="text-2xl font-bold mb-6 text-center text-slate-800">
        Вхід до системи
      </h2>
      <form action={action} className="space-y-4">
        <div>
          <input type="hidden" name="returnUrl" value={returnUrl || ""} />
          <label
            htmlFor="email"
            className="block text-sm font-medium text-slate-700 mb-1"
          >
            Email
          </label>
          <input
            id="email"
            name="email"
            type="email"
            required
            className="w-full px-3 py-2 border border-slate-300 rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-500"
          />
        </div>
        {state?.errors?.email && (
          <div className="mb-4 p-3 bg-red-50 text-red-600 rounded-lg">
            {state.errors.email}
          </div>
        )}
        <div>
          <label
            htmlFor="password"
            className="block text-sm font-medium text-slate-700 mb-1"
          >
            Пароль
          </label>
          <input
            id="password"
            name="password"
            type="password"
            required
            className="w-full px-3 py-2 border border-slate-300 rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-500"
          />
        </div>
        {state?.errors?.password && (
          <div className="mb-4 p-3 bg-red-50 text-red-600 rounded-lg">
            {state.errors.password}
          </div>
        )}
        <button
          type="submit"
          disabled={pending}
          className="w-full bg-blue-600 text-white py-2 px-4 rounded-lg hover:bg-blue-700 focus:outline-none focus:ring-2 focus:ring-blue-500 focus:ring-offset-2 disabled:opacity-50 disabled:cursor-not-allowed"
        >
          {pending ? "Вхід..." : "Увійти"}
        </button>
      </form>
    </div>
  );
}
