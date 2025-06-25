import type { ContentSection, Topic } from "@/shared/types/domain";

export default function getTopics(content: ContentSection[]): Topic[] {
  return content.flatMap((section) => 
    section.sections.flatMap((subsection) => subsection.topics)
  );
}
