import { z } from "zod";

export const SignInFormSchema = z.object({
  //   email: z.string().email({ message: "Please enter a valid email." }).trim(),
  email: z.string().trim(),
  password: z
    .string()
    // .min(8, { message: "Be at least 8 characters long" })
    // .regex(/[a-zA-Z]/, { message: "Contain at least one letter." })
    // .regex(/[0-9]/, { message: "Contain at least one number." })
    // .regex(/[^a-zA-Z0-9]/, {
    //   message: "Contain at least one special character.",
    // })
    .trim(),
});

export type FormState =
  | {
      errors?: {
        email?: string[];
        password?: string[];
      };
      message?: string;
    }
  | undefined;
