"use client";
import { useState } from "react";

type QuestionType = "Regular" | "MultipleChoice" | "OpenEnded";

interface AnswerResponse {
  id: number;
  answerText: string;
  isCorrect: boolean;
}

interface QuestionResponse {
  id: number;
  questionText: string;
  type: QuestionType;
  lessonId: number;
  schoolId: number;
  answers: AnswerResponse[];
}

interface Test {
  id: string;
  slug: string;
  title: string;
  questions: QuestionResponse[];
}

interface TestProps {
  test: Test | undefined; // Accept test object as prop
}

// Remove mock data
// const testsMock: Test[] = [ ... ];

// Accept test object as prop
export default function Test({ test }: TestProps) {
  const [answers, setAnswers] = useState<Record<number, number[]>>({});
  const [openEndedAnswers, setOpenEndedAnswers] = useState<
    Record<number, string>
  >({});
  const [isSubmitted, setIsSubmitted] = useState(false);

  // Removed logic to find test by id
  // const test = testsMock.find((t) => t.id === parseInt(id));

  if (!test) {
    return (
      <div className="flex flex-col items-center justify-center h-full text-slate-800">
        <h2 className="text-2xl font-bold mb-4">
          Тест не знайдено або завантажується
        </h2>
        {/* Updated message */}
        <p>Будь ласка, спробуйте пізніше або виберіть інший тест.</p>
        {/* Updated message */}
      </div>
    );
  }

  const handleAnswerChange = (questionId: number, answerId: number) => {
    setAnswers((prev) => {
      const question = test.questions.find((q) => q.id === questionId);
      if (!question) return prev;

      if (question.type === "Regular") {
        return { ...prev, [questionId]: [answerId] };
      } else if (question.type === "MultipleChoice") {
        const currentAnswers = prev[questionId] || [];
        if (currentAnswers.includes(answerId)) {
          return {
            ...prev,
            [questionId]: currentAnswers.filter((v) => v !== answerId),
          };
        } else {
          return {
            ...prev,
            [questionId]: [...currentAnswers, answerId],
          };
        }
      }
      return prev;
    });
  };

  const handleOpenEndedChange = (questionId: number, value: string) => {
    setOpenEndedAnswers((prev) => ({
      ...prev,
      [questionId]: value,
    }));
  };

  const handleSubmit = () => {
    setIsSubmitted(true);
  };

  const calculateScore = () => {
    let correct = 0;
    let total = 0;

    test.questions.forEach((question) => {
      if (question.type === "OpenEnded") {
        const userAnswer = openEndedAnswers[question.id] || "";
        const correctAnswer = question.answers[0]?.answerText || "";
        
        // Case-insensitive comparison with trimmed whitespace for open-ended questions
        if (userAnswer.toLowerCase().trim() === correctAnswer.toLowerCase().trim()) {
          correct++;
        }
        total++;
        return;
      }

      const userAnswers = answers[question.id] || [];
      const correctAnswers = question.answers
        .filter((a) => a.isCorrect)
        .map((a) => a.id);

      const isCorrect =
        userAnswers.length === correctAnswers.length &&
        userAnswers.every((answer) => correctAnswers.includes(answer));
      if (isCorrect) correct++;
      total++;
    });

    return { correct, total };
  };

  const renderQuestionInput = (question: QuestionResponse) => {
    switch (question.type) {
      case "Regular":
        return (
          <div className="space-y-2">
            {question.answers.map((answer, aIdx) => (
              <label
                key={`${answer.id}-${aIdx}`}
                className="flex items-center space-x-3 p-3 rounded-lg border border-slate-200 hover:bg-slate-50 cursor-pointer"
              >
                <input
                  type="radio"
                  name={question.id.toString()}
                  value={answer.id}
                  onChange={(e) =>
                    handleAnswerChange(question.id, parseInt(e.target.value))
                  }
                  className="h-4 w-4 text-blue-600"
                />
                <span>{answer.answerText}</span>
              </label>
            ))}
          </div>
        );
      case "MultipleChoice":
        return (
          <div className="space-y-2">
            {question.answers.map((answer, aIdx) => (
              <label
                key={`${answer.id}-${aIdx}`}
                className="flex items-center space-x-3 p-3 rounded-lg border border-slate-200 hover:bg-slate-50 cursor-pointer"
              >
                <input
                  type="checkbox"
                  name={question.id.toString()}
                  value={answer.id}
                  onChange={(e) =>
                    handleAnswerChange(question.id, parseInt(e.target.value))
                  }
                  className="h-4 w-4 text-blue-600"
                />
                <span>{answer.answerText}</span>
              </label>
            ))}
          </div>
        );
      case "OpenEnded":
        return (
          <textarea
            className="w-full p-3 border border-slate-200 rounded-lg focus:ring-2 focus:ring-blue-500 focus:border-blue-500"
            rows={4}
            placeholder="Введіть вашу відповідь..."
            value={openEndedAnswers[question.id] || ""}
            onChange={(e) => handleOpenEndedChange(question.id, e.target.value)}
          />
        );
    }
  };

  return (
    <div className="max-w-3xl mx-auto bg-white rounded-lg shadow p-8 mt-8 text-slate-800">
      <h1 className="text-3xl font-bold mb-8">{test.title}</h1>

      {!isSubmitted ? (
        <form
          onSubmit={(e) => {
            e.preventDefault();
            handleSubmit();
          }}
        >
          {test.questions.map((question, qIdx) => (
            <div key={`${question.id}-${qIdx}`} className="mb-8">
              <h3 className="text-xl font-semibold mb-4">
                {question.questionText}
              </h3>
              {renderQuestionInput(question)}
            </div>
          ))}
          <div className="flex justify-center">
            <button
              type="submit"
              className="bg-blue-600 hover:bg-blue-700 text-white font-semibold py-2 px-6 rounded-lg transition-colors duration-200"
            >
              Завершити тест
            </button>
          </div>
        </form>
      ) : (
        <div className="text-center">
          <h2 className="text-2xl font-bold mb-4">Результати тесту</h2>
          {(() => {
            const { correct, total } = calculateScore();
            return (
              <div className="mb-6">
                <p className="text-xl">
                  Правильних відповідей: {correct} з {total}
                </p>
                <p className="text-lg text-slate-600">
                  ({Math.round((correct / total) * 100)}%)
                </p>
              </div>
            );
          })()}
          <div className="space-y-4">
            {test.questions.map((question) => {
              const questionKey = `question-${question.id}`;

              if (question.type === "OpenEnded") {
                const userAnswer = openEndedAnswers[question.id] || "";
                const correctAnswer = question.answers[0]?.answerText || "";
                const isCorrect = userAnswer.toLowerCase().trim() === correctAnswer.toLowerCase().trim();

                return (
                  <div
                    key={questionKey}
                    className={`p-4 rounded-lg ${
                      isCorrect ? "bg-green-50" : "bg-red-50"
                    }`}
                  >
                    <p className="font-semibold mb-2">
                      {question.questionText}
                    </p>
                    <p className="text-sm">
                      Ваша відповідь:{" "}
                      {userAnswer || "Немає відповіді"}
                    </p>
                    {!isCorrect && (
                      <p className="text-sm text-green-600">
                        Правильна відповідь: {correctAnswer}
                      </p>
                    )}
                  </div>
                );
              }

              const userAnswers = answers[question.id] || [];
              const correctAnswers = question.answers
                .filter((a) => a.isCorrect)
                .map((a) => a.id);

              const isCorrect =
                userAnswers.length === correctAnswers.length &&
                userAnswers.every((answer) => correctAnswers.includes(answer));

              return (
                <div
                  key={questionKey}
                  className={`p-4 rounded-lg ${
                    isCorrect ? "bg-green-50" : "bg-red-50"
                  }`}
                >
                  <p className="font-semibold mb-2">{question.questionText}</p>
                  <p className="text-sm">
                    Ваші відповіді:{" "}
                    {userAnswers
                      .map(
                        (answerId) =>
                          question.answers.find((a) => a.id === answerId)
                            ?.answerText
                      )
                      .filter(Boolean)
                      .join(", ") || "Немає відповіді"}
                  </p>
                  {!isCorrect && (
                    <p className="text-sm text-green-600">
                      Правильні відповіді:{" "}
                      {question.answers
                        .filter((a) => a.isCorrect)
                        .map((a) => a.answerText)
                        .join(", ")}
                    </p>
                  )}
                </div>
              );
            })}
          </div>
        </div>
      )}
    </div>
  );
}
