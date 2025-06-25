import Lesson from "@/pages/Lesson/ui";

export default async function LessonPage({
  params,
}: {
  params: { params: string[] };
}) {
  const { params: routeParams } = await params;
  const [sectionId, subsectionId, topicId] = routeParams || [];
  return (
    <Lesson
      sectionId={sectionId}
      subsectionId={subsectionId}
      topicId={topicId}
    />
  );
}
