import content from "@/shared/config/content";

interface LessonNavigation {
  prevLessonUrl: string | null;
  nextLessonUrl: string | null;
}

export function getLessonNavigation(
  currentSectionId: string,
  currentSubsectionId: string,
  currentTopicId: string
): LessonNavigation {
  let prevLessonUrl: string | null = null;
  let nextLessonUrl: string | null = null;

  let foundCurrent = false;

  for (let i = 0; i < content.length; i++) {
    const section = content[i];
    for (let j = 0; j < section.sections.length; j++) {
      const subsection = section.sections[j];
      for (let k = 0; k < subsection.topics.length; k++) {
        const topic = subsection.topics[k];

        const topicSlug = `${section.id}/${subsection.id}/${topic.id}`;

        if (
          section.id.toString() === currentSectionId &&
          subsection.id.toString() === currentSubsectionId &&
          topic.id.toString() === currentTopicId
        ) {
          foundCurrent = true;

          // Find next lesson
          if (k + 1 < subsection.topics.length) {
            // Next topic in same subsection
            const nextTopic = subsection.topics[k + 1];
            nextLessonUrl = `${section.id}/${subsection.id}/${nextTopic.id}`;
          } else if (j + 1 < section.sections.length) {
            // Next subsection in same section
            const nextSubsection = section.sections[j + 1];
            const nextTopic = nextSubsection.topics[0]; // First topic of next subsection
            nextLessonUrl = `${section.id}/${nextSubsection.id}/${nextTopic.id}`;
          } else if (i + 1 < content.length) {
            // Next section
            const nextSection = content[i + 1];
            const nextSubsection = nextSection.sections[0]; // First subsection of next section
            const nextTopic = nextSubsection.topics[0]; // First topic of first subsection
            nextLessonUrl = `${nextSection.id}/${nextSubsection.id}/${nextTopic.id}`;
          }

          // We've found the current lesson and identified the next, so we can break here if prev was already found.
          if (prevLessonUrl) return { prevLessonUrl, nextLessonUrl };
        } else if (!foundCurrent) {
          // This means the current topic is not yet found, so this is a potential previous lesson
          prevLessonUrl = topicSlug;
        } else if (foundCurrent) {
          // This means the current topic was found in the previous iteration,
          // and this is the next lesson. We can set nextLessonUrl and break.
          nextLessonUrl = topicSlug;
          return { prevLessonUrl, nextLessonUrl };
        }
      }
    }
  }

  return { prevLessonUrl, nextLessonUrl };
} 