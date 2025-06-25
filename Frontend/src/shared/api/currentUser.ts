import { createContext } from "react";

interface User {
  id: string;
  role: number;
  login: string;
  // Add other user properties as needed
}

export const CurrentUser = createContext<User | null>(null);
