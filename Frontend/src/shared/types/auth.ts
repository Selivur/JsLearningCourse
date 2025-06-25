export type User = {
  token: string;
  "http://schemas.microsoft.com/ws/2008/06/identity/claims/role":
    | "Student"
    | "Teacher"
    | "Admin";
  'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier': string,
  'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name': string,
  SchoolId: string,
  exp: 1749420241,
  iss: 'YourIssuer',
  aud: 'YourAudience'
};

export type UserDecoded = User & {
  schoolId: string;
  role: "student" | "teacher" | "admin";
};

export type AuthError = {
  message: string;
  code: string;
};
