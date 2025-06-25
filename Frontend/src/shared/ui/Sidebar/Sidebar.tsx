import { getSession } from "@/shared/lib/auth";
import Nav from "./Nav";
import { User } from "./User";
import { getUserFromToken } from "@/shared/utils/getUserFromToken";
import Link from "next/link";

export default async function Sidebar() {
  const token = await getSession();
  const user = await getUserFromToken(token);

  return (
    <div className="flex flex-col justify-between w-80 h-screen bg-slate-800 p-6 text-white overflow-y-auto">
      <div>
        <h1 className="text-2xl font-semibold mb-8">Уроки JavaScript</h1>
        <Nav />
      </div>
      <div className="flex flex-col items-stretch gap-4 mt-8">
        {user ? (
          <User user={user} />
        ) : (
          <Link
            href="/login"
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
            Увійти
          </Link>
        )}
      </div>
    </div>
  );
}
