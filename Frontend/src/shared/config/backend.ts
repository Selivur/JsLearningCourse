//export const backendApiUrl = "http://localhost:8080";
export const backendApiUrl = "http://localhost:5000";
export const api = {
  question: {
    get: (id: string) => `${backendApiUrl}/api/Question/lesson/${id}`,
    edit: (id: string) => `${backendApiUrl}/api/Question/list/${id}`,
    getTeacher: (id: string) =>
      `${backendApiUrl}/api/Question/lesson/edit/${id}`,
  },
  user: {
    createStudent: () => `${backendApiUrl}/api/User/createStudent`,
  },
};
