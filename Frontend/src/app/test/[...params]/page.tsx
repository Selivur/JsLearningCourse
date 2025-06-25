import Test from "@/pages/Test/Test";
import { api } from "@/shared/config/backend";
import { getSession } from "@/shared/lib/auth";
import { Suspense } from "react";
import { Test as TestType, QuestionResponse } from "@/pages/Test/edit/TestPage"; 

interface PageProps {
  params: { params: string[] };
}

export default async function TestPage({ params }: PageProps) {
  const { params: routeParams } = await params;
  const [sectionId, subsectionId, topicId] = routeParams || [];
  const testSlug = `${sectionId}/${subsectionId}/${topicId}`;
  const lessonId = `${sectionId}.${subsectionId}`;
  const token = await getSession();
  let testData: TestType | undefined = undefined; 

  try {
    const response = await fetch(api.question.get(lessonId), {
      method: "GET",
      headers: {
        "Content-Type": "application/json",
        Authorization: `Bearer ${token}`,
      },
    });

    if (!response.ok) {
      console.error(
        `Error fetching questions for lesson ${lessonId}: ${response.status}`
      );
    } else {
      const questions: QuestionResponse[] = await response.json();

      if (Array.isArray(questions)) {
        // Construct a Test object
        testData = {
          id: lessonId, // Using lessonId as test id
          slug: testSlug,
          title: `Тест до розділу ${lessonId}`, // Placeholder title
          questions: questions,
        };
      } else {
        console.error("Fetched data is not an array of questions:", questions);
      }
    }
  } catch (error) {
    console.error("Error during question data fetch:", error);
  }
  if(!testData)
    return null;
  return (
    <Suspense fallback={<div>Завантаження...</div>}>
      {/* @ts-expect-error ts(2322) */}
      <Test test={testData} />
    </Suspense>
  );
}
