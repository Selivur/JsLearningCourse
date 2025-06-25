import { AddStudentPage } from "@/pages/Student";
import { getSession } from "@/shared/lib/auth";

export default async function AddStudent() {
  const token = await getSession();  
  if(!token)
    return null
  return <AddStudentPage token={token} />;
}
