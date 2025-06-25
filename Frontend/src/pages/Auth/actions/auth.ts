import { loginRoute } from "@/pages/Auth/config/routes";
import { FormState, SignInFormSchema } from "@/pages/Auth/definitions";
import { backendApiUrl } from "@/shared/config/backend";
import { createSession } from "@/shared/lib/auth";
import { User } from "@/shared/types/auth";
import { redirect } from "next/navigation";

export async function signin(state: FormState, formData: FormData) {
  const returnUrl = formData.get("returnUrl") as string;
  const validatedFields = SignInFormSchema.safeParse({
    email: formData.get("email"),
    password: formData.get("password"),
  });

  if (!validatedFields.success) {
    return {
      errors: validatedFields.error.flatten().fieldErrors,
    };
  }

  const email = formData.get("email");
  const password = formData.get("password");

  const response = await fetch(`${backendApiUrl}${loginRoute}`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({ login: email, password }),
  });

  if (!response.ok) {
    return {
      errors: {
        email: ["Invalid email or password"],
      },
    };
  }

  const data = (await response.json()) as User;

  await createSession(data.token);

  redirect(returnUrl || "/");
}
