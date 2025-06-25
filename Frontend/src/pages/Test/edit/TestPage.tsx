"use client";
import { useState, ChangeEvent } from "react";
import { useRouter } from "next/navigation";
import { api } from "@/shared/config/backend";

export type QuestionType = "Regular" | "MultipleChoice" | "OpenEnded";

export interface AnswerResponse {
  id: number | null;
  answerText: string;
  isCorrect: boolean;
}

export interface QuestionResponse {
  id: number | null;
  questionText: string;
  type: QuestionType;
  lessonId: string;
  schoolId: number;
  answers: AnswerResponse[];
}

export interface Test {
  id: string;
  slug: string;
  title: string;
  questions: QuestionResponse[];
}

interface TestPageProps {
  test: Test | undefined;
  token: string | null;
  schoolId: string;
  lessonId: string;
}

const defaultQuestion = (): QuestionResponse => ({
  id: null,
  type: "Regular",
  questionText: "",
  lessonId: "",
  schoolId: 1,
  answers: [{ id: null, answerText: "", isCorrect: false }],
});

export default function TestPage({ test: initialTest, token, schoolId, lessonId }: TestPageProps) {
  const [test, setTest] = useState<Test | undefined>(initialTest);
  const router = useRouter();

  const handleTitleChange = (e: ChangeEvent<HTMLInputElement>) => {
    if (!test) return;
    const updatedTest: Test = {
      id: test.id,
      slug: test.slug,
      title: e.target.value,
      questions: test.questions,
    };
    setTest(updatedTest);
  };

  const handleQuestionChange = <K extends keyof QuestionResponse>(
    qIdx: number,
    field: K,
    value: QuestionResponse[K]
  ) => {
    if (!test) return;
    const questions = [...test.questions];
    questions[qIdx] = { ...questions[qIdx], [field]: value };
    const updatedTest: Test = {
      id: test.id,
      slug: test.slug,
      title: test.title,
      questions,
    };
    setTest(updatedTest);
  };

  const handleAnswerChange = <K extends keyof AnswerResponse>(
    qIdx: number,
    aIdx: number,
    field: K,
    value: AnswerResponse[K]
  ) => {
    if (!test) return;
    const questions = [...test.questions];
    const answers = [...questions[qIdx].answers];
    answers[aIdx] = { ...answers[aIdx], [field]: value };
    questions[qIdx] = { ...questions[qIdx], answers };
    const updatedTest: Test = {
      id: test.id,
      slug: test.slug,
      title: test.title,
      questions,
    };
    setTest(updatedTest);
  };

  const addAnswer = (qIdx: number) => {
    if (!test) return;
    const questions = [...test.questions];
    const answers = [
      ...questions[qIdx].answers,
      { id: Date.now(), answerText: "", isCorrect: false },
    ];
    questions[qIdx] = { ...questions[qIdx], answers };
    const updatedTest: Test = {
      id: test.id,
      slug: test.slug,
      title: test.title,
      questions,
    };
    setTest(updatedTest);
  };

  const addQuestion = () => {
    if (!test) return;
    const updatedDefaultQuestion ={
      ...defaultQuestion(),
      schoolId: Number(schoolId),
      lessonId
    }
    const updatedTest: Test = {
      id: test.id,
      slug: test.slug,
      title: test.title,
      questions: [...test.questions, updatedDefaultQuestion],
    };
    setTest(updatedTest);
  };

  const removeAnswer = (qIdx: number, aIdx: number) => {
    if (!test) return;
    const questions = [...test.questions];
    const answers = questions[qIdx].answers.filter((_, i) => i !== aIdx);
    questions[qIdx] = { ...questions[qIdx], answers };
    const updatedTest: Test = {
      id: test.id,
      slug: test.slug,
      title: test.title,
      questions,
    };
    setTest(updatedTest);
  };

  const removeQuestion = (qIdx: number) => {
    if (!test) return;
    const questions = test.questions.filter((_, i) => i !== qIdx);
    const updatedTest: Test = {
      id: test.id,
      slug: test.slug,
      title: test.title,
      questions: questions.length === 0 ? [defaultQuestion()] : questions,
    };
    setTest(updatedTest);
  };

  const handleSave = async () => {
    if (!test) return;
    try {
      const validQuestions = test.questions.filter(q => q.questionText.trim() !== '');

      const response = await fetch(api.question.edit(lessonId), {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
          Authorization: `Bearer ${token}`,
        },
        body: JSON.stringify(validQuestions),
      });

      if (!response.ok) {
        throw new Error("Помилка при збереженні тесту");
      }

      alert("Тест успішно збережено!");
      router.push(`/lesson/${test.slug}`);
    } catch (error) {
      alert(error instanceof Error ? error.message : "Сталася помилка");
    }
  };

  if (!test || !test.questions) {
    return <div>Test not found or loading...</div>;
  }

  return (
    <div className="max-w-3xl mx-auto bg-white rounded-lg shadow p-8 mt-8 text-slate-800">
      <h1 className="text-3xl font-bold mb-8">Створити тест</h1>
      <div className="mb-6">
        <label className="block text-lg font-semibold mb-2">Назва тесту</label>
        <input
          className="w-full p-3 border border-slate-200 rounded-lg focus:ring-2 focus:ring-blue-500 focus:border-blue-500"
          value={test.title}
          onChange={handleTitleChange}
          placeholder="Введіть назву тесту"
        />
      </div>
      {test.questions.map((q, qIdx) => (
        <div key={`${q.id}-${qIdx}`} className="mb-8 border-b pb-6">
          <div className="flex items-center mb-2">
            <label className="block text-md font-semibold mr-2">
              Питання {qIdx + 1}
            </label>
            <button
              type="button"
              className="ml-auto text-red-500 hover:underline"
              onClick={() => removeQuestion(qIdx)}
            >
              Видалити питання
            </button>
          </div>
          <input
            className="w-full p-2 border border-slate-200 rounded mb-2"
            value={q.questionText}
            onChange={(e) =>
              handleQuestionChange(qIdx, "questionText", e.target.value)
            }
            placeholder="Текст питання"
          />
          <div className="mb-2">
            <label className="block text-sm font-medium mb-1">
              Тип питання
            </label>
            <select
              className="p-2 border border-slate-200 rounded"
              value={q.type}
              onChange={(e) =>
                handleQuestionChange(
                  qIdx,
                  "type",
                  e.target.value as QuestionType
                )
              }
            >
              <option value="Regular">Одна відповідь</option>
              <option value="MultipleChoice">Кілька відповідей</option>
              <option value="OpenEnded">Відкрите питання</option>
            </select>
          </div>
          {q.type !== "OpenEnded" && (
            <div>
              <label className="block text-sm font-medium mb-1">
                Варіанти відповідей
              </label>
              {q.answers.map((a, aIdx) => (
                <div key={`${a.id}-${aIdx}`} className="flex items-center mb-2">
                  <input
                    className="flex-1 p-2 border border-slate-200 rounded mr-2"
                    value={a.answerText}
                    onChange={(e) =>
                      handleAnswerChange(
                        qIdx,
                        aIdx,
                        "answerText",
                        e.target.value
                      )
                    }
                    placeholder={`Варіант ${aIdx + 1}`}
                  />
                  <label className="flex items-center mr-2">
                    <input
                      type={q.type === "Regular" ? "radio" : "checkbox"}
                      checked={a.isCorrect}
                      onChange={(e) =>
                        handleAnswerChange(
                          qIdx,
                          aIdx,
                          "isCorrect",
                          e.target.checked
                        )
                      }
                      name={`correct-${q.id}`}
                    />
                    <span className="ml-1 text-xs">Правильна</span>
                  </label>
                  <button
                    type="button"
                    className="text-red-400 hover:text-red-600 ml-2"
                    onClick={() => removeAnswer(qIdx, aIdx)}
                    disabled={q.answers.length === 1}
                  >
                    —
                  </button>
                </div>
              ))}
              <button
                type="button"
                className="mt-2 text-blue-600 hover:underline"
                onClick={() => addAnswer(qIdx)}
              >
                + Додати варіант
              </button>
            </div>
          )}
          {q.type === "OpenEnded" && (
            <div>
              <label className="block text-sm font-medium mb-1">
                Правильна відповідь
              </label>
              <input
                className="w-full p-2 border border-slate-200 rounded"
                value={q.answers[0]?.answerText || ""}
                onChange={(e) =>
                  handleAnswerChange(qIdx, 0, "answerText", e.target.value)
                }
                placeholder="Введіть правильну відповідь"
              />
            </div>
          )}
        </div>
      ))}
      <button
        type="button"
        className="bg-blue-600 hover:bg-blue-700 text-white font-semibold py-2 px-6 rounded-lg transition-colors duration-200 mb-6"
        onClick={addQuestion}
      >
        + Додати питання
      </button>
      <div className="flex justify-end">
        <button
          type="button"
          className="bg-green-600 hover:bg-green-700 text-white font-semibold py-2 px-6 rounded-lg transition-colors duration-200"
          onClick={handleSave}
        >
          Зберегти тест
        </button>
      </div>
    </div>
  );
}
