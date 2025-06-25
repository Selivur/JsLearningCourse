import data from "@/shared/config/content";
import Image from "next/image";
import Link from "next/link";
import ReactMarkdown from "react-markdown";
import { Prism as SyntaxHighlighter } from "react-syntax-highlighter";
import { vscDarkPlus } from "react-syntax-highlighter/dist/esm/styles/prism";
import { getLessonNavigation } from "@/shared/lib/lessonNavigation";

export default function Lesson({
  sectionId,
  subsectionId,
  topicId,
}: {
  sectionId: string;
  subsectionId: string;
  topicId: string;
}) {
  const section = data.find((s) => s.id === Number(sectionId));
  const subsection = section?.sections.find(
    (ss) => ss.id === Number(subsectionId)
  );
  const topic = subsection?.topics.find((t) => t.id === Number(topicId));
  const { prevLessonUrl, nextLessonUrl } = getLessonNavigation(
    sectionId,
    subsectionId,
    topicId
  );

  if (!topic) {
    return (
      <div className="flex flex-col items-center justify-center h-full text-slate-800">
        <h2 className="text-2xl font-bold mb-4">Урок не знайдено</h2>
        <p>Спробуйте вибрати інший урок у меню.</p>
      </div>
    );
  }

  const renderedContent = topic.content.map((c) => {
    switch (c.type) {
      case "heading":
        return (
          <h2 key={c.text} className="text-3xl font-bold mb-4">
            {c.text}
          </h2>
        );
      case "subheading":
        return (
          <h3
            key={c.text}
            className="text-xl font-semibold mb-2 text-slate-600"
          >
            {c.text}
          </h3>
        );
      case "paragraph":
        return (
          <div key={c.text} className="mb-6 text-lg leading-relaxed">
            <ReactMarkdown>{c.text}</ReactMarkdown>
          </div>
        );
      case "image":
        return (
          <div key={c.src} className="my-6" >
            <div className="relative h-full" style={{height:500}}>
            <Image
              src={c.src}
              alt={c.alt}
              fill
              objectFit="contain"
              className="w-full h-auto rounded-lg shadow-lg"
              priority
            />
            </div>
            <p className="text-center text-sm text-gray-600 mt-2">{c.alt}</p>
          </div>
        );
      case "list":
        return (
          <ul
            key={c.items.join()}
            className="list-disc pl-6 mb-6 text-lg leading-relaxed"
          >
            {c.items.map((item, index) => (
              <li key={index} className="mb-2">
                <ReactMarkdown>{item}</ReactMarkdown>
              </li>
            ))}
          </ul>
        );
      case "code":
        return (
          <div key={c.code} className="mb-6">
            <SyntaxHighlighter
              language={c.language || "javascript"}
              style={vscDarkPlus}
              customStyle={{
                borderRadius: "0.5rem",
                padding: "1rem",
                fontSize: "1rem",
                lineHeight: "1.5",
              }}
            >
              {c.code}
            </SyntaxHighlighter>
          </div>
        );
      default:
        return null;
    }
  });

  return (
    <div className="max-w-5xl mx-auto bg-white rounded-lg shadow p-8 mt-8 text-slate-800">
      <div className="flex flex-col gap-4">{renderedContent}</div>

      <div className="flex justify-between mt-8">
        {prevLessonUrl && (
          <Link
            href={`/lesson/${prevLessonUrl}`}
            className="inline-block bg-blue-600 hover:bg-blue-700 text-white font-semibold py-2 px-6 rounded-lg transition-colors duration-200"
          >
            &larr; Попередній урок
          </Link>
        )}
        {topic.test && (
          <Link
            href={`/test/${sectionId}/${subsectionId}/${topicId}`}
            className="inline-block bg-blue-600 hover:bg-blue-700 text-white font-semibold py-2 px-6 rounded-lg transition-colors duration-200"
          >
            Пройти тест
          </Link>
        )}
        {nextLessonUrl && (
          <Link
            href={`/lesson/${nextLessonUrl}`}
            className="inline-block bg-blue-600 hover:bg-blue-700 text-white font-semibold py-2 px-6 rounded-lg transition-colors duration-200"
          >
            Наступний урок &rarr;
          </Link>
        )}
      </div>
    </div>
  );
}
