"use client";

import content from "@/shared/config/content";
import Link from "next/link";
import { usePathname, useSearchParams, useRouter } from "next/navigation";
import { useState, useEffect } from "react";

export default function Nav() {
  const pathname = usePathname();
  const searchParams = useSearchParams();
  const router = useRouter();
  
  const [openSection, setOpenSection] = useState<number | null>(null);
  const [openSubsection, setOpenSubsection] = useState<number | null>(null);

  // Ініціалізація стану з URL параметрів при завантаженні
  useEffect(() => {
    if (!searchParams) return;
    const section = searchParams.get('section');
    const subsection = searchParams.get('subsection');
    if (section) setOpenSection(Number(section));
    if (subsection) setOpenSubsection(Number(subsection));
  }, [searchParams]);

  const handleOpenSection = (id: number) => {
    const newSection = openSection === id ? null : id;
    setOpenSection(newSection);
    
    // Оновлюємо URL параметри
    const params = new URLSearchParams(searchParams?.toString() || '');
    if (newSection) {
      params.set('section', newSection.toString());
    } else {
      params.delete('section');
      params.delete('subsection');
    }
    router.push(`${pathname}?${params.toString()}`);
  };

  const handleOpenSubsection = (id: number) => {
    const newSubsection = openSubsection === id ? null : id;
    setOpenSubsection(newSubsection);
    
    // Оновлюємо URL параметри
    const params = new URLSearchParams(searchParams?.toString() || '');
    if (newSubsection) {
      params.set('subsection', newSubsection.toString());
    } else {
      params.delete('subsection');
    }
    router.push(`${pathname}?${params.toString()}`);
  };

  // Функція для перевірки чи є посилання активним
  const isActiveLink = (lessonId: number, sectionId: number, topicId: number) => {
    return pathname === `/lesson/${lessonId}/${sectionId}/${topicId}`;
  };

  return (
    <nav>
      <ul className="space-y-4">
        {content.map(({ id, title, sections }) => (
          <li key={id}>
            <button
              className="w-full text-left font-bold px-4 py-3 rounded hover:bg-slate-700 focus:bg-slate-700"
              onClick={() => handleOpenSection(id)}
            >
              {title}
            </button>
            {openSection === id && (
              <ul className="ml-4 mt-2 space-y-2">
                {sections.map((section) => (
                  <li key={section.id}>
                    <button
                      className="w-full text-left font-semibold px-4 py-2 rounded hover:bg-slate-700 focus:bg-slate-700"
                      onClick={() => handleOpenSubsection(section.id)}
                    >
                      {section.title}
                    </button>
                    {openSubsection === section.id && (
                      <ul className="ml-4 mt-2 space-y-2">
                        {section.topics.map((topic) => (
                          <li key={topic.id}>
                            <Link
                              href={`/lesson/${id}/${section.id}/${topic.id}?section=${id}&subsection=${section.id}`}
                              className={`block px-4 py-2 rounded hover:bg-slate-700 focus:bg-slate-700 text-sm ${
                                isActiveLink(id, section.id, topic.id)
                                  ? "bg-slate-700 text-white"
                                  : ""
                              }`}
                            >
                              {topic.title}
                            </Link>
                          </li>
                        ))}
                      </ul>
                    )}
                  </li>
                ))}
              </ul>
            )}
          </li>
        ))}
      </ul>
    </nav>
  );
}
