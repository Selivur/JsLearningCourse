import TestPage, { Test } from "@/pages/Test/edit/TestPage";
import { api } from "@/shared/config/backend";
import { getSession } from "@/shared/lib/auth";
import { Suspense } from "react";
import { QuestionResponse } from "@/pages/Test/edit/TestPage";
import { getUserFromToken } from "@/shared/utils/getUserFromToken";
import { UserDecoded } from "@/shared/types/auth";

interface PageProps {
  params: { params: string[] };
}

export default async function Page({ params }: PageProps) {
  const { params: routeParams } = await params;
  const [sectionId, subsectionId, topicId] = routeParams || [];
  const testSlug = `${sectionId}/${subsectionId}/${topicId}`;
  const questionId = `${sectionId}.${subsectionId}`;
  const token = await getSession();
  const user = await getUserFromToken(token) as UserDecoded;
  let testData: Test | undefined = undefined;

  try {
    const response = await fetch(api.question.getTeacher(questionId), {
      method: "GET",
      headers: {
        "Content-Type": "application/json",
        Authorization: `Bearer ${token}`,
      },
    });
    if (!response.ok) {
      console.error(
        `Error fetching questions for lesson ${questionId}: ${response.status}`
      );
    } else {
      const questions: QuestionResponse[] = await response.json();
      if (Array.isArray(questions)) {
        testData = {
          id: questionId,
          slug: testSlug,
          title: `Тест до уроку ${questionId}`,
          questions: questions,
        };
      } else {
        console.error("Fetched data is not an array of questions:", questions);
      }
    }
  } catch (error) {
    console.error("Error during question data fetch:", error);
  }

  return (
    <Suspense fallback={<div>Завантаження...</div>}>
      <TestPage test={testData} token={token} schoolId={user["SchoolId"]} lessonId={questionId} />
    </Suspense>
  );
}
