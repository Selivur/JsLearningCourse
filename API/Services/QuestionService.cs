using API.Models.Question;
using API.Services.Interfaces;
using Database.Models;
using Database.Repositories;
using System.Text.RegularExpressions;

namespace API.Services
{
    /// <summary>
    /// Implementation of the <see cref="IQuestionService"/> interface.
    /// Provides functionality for question management and retrieval.
    /// </summary>
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IAnswerRepository _answerRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="QuestionService"/> class.
        /// </summary>
        /// <param name="questionRepository">The repository for question data operations.</param>
        /// <param name="answerRepository">The repository for answer data operations.</param>
        public QuestionService(IQuestionRepository questionRepository, IAnswerRepository answerRepository)
        {
            _questionRepository = questionRepository;
            _answerRepository = answerRepository;
        }

        /// <inheritdoc/>
        public async Task<QuestionResponse> CreateQuestionAsync(CreateQuestionRequest request)
        {
            var question = new Question
            {
                QuestionText = request.QuestionText,
                Type = request.Type,
                LessonId = request.LessonId,
                SchoolId = request.SchoolId,
                Answers = request.Answers.Select(a => new Answer
                {
                    AnswerText = request.Type == QuestionType.OpenEnded ? NormalizeText(a.AnswerText) : a.AnswerText,
                    IsCorrect = a.IsCorrect
                }).ToList()
            };

            var createdQuestion = await _questionRepository.CreateAsync(question);
            return MapToResponse(createdQuestion, createdQuestion.Answers);
        }

        /// <inheritdoc/>
        public async Task<QuestionResponse> UpdateQuestionAsync(CreateQuestionRequest request)
        {
            if (!request.Id.HasValue)
                throw new ArgumentException("Question ID is required for update operation.");

            var existingQuestion = await _questionRepository.GetByIdAsync(request.Id.Value);
            if (existingQuestion == null)
                throw new KeyNotFoundException($"Question with ID {request.Id} not found.");

            existingQuestion.QuestionText = request.QuestionText;
            existingQuestion.Type = request.Type;
            existingQuestion.LessonId = request.LessonId;
            existingQuestion.SchoolId = request.SchoolId;

            // Update answers
            var existingAnswers = await _answerRepository.GetByQuestionIdAsync(existingQuestion.Id);
            foreach (var existingAnswer in existingAnswers)
            {
                await _answerRepository.DeleteAsync(existingAnswer.Id);
            }

            existingQuestion.Answers = request.Answers.Select(a => new Answer
            {
                AnswerText = request.Type == QuestionType.OpenEnded ? NormalizeText(a.AnswerText) : a.AnswerText,
                IsCorrect = a.IsCorrect
            }).ToList();

            var updatedQuestion = await _questionRepository.UpdateAsync(existingQuestion);
            return MapToResponse(updatedQuestion, updatedQuestion.Answers);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<QuestionResponse>> GetQuestionsByLessonAndSchoolIdAsync(double lessonId, int schoolId)
        {
            var questions = await _questionRepository.GetByLessonIdAsync(lessonId);
            return questions
                .Where(q => q.SchoolId == schoolId)
                .Select(q => MapToResponse(q, q.Answers));
        }

        /// <inheritdoc/>
        public async Task<bool> DeleteQuestionsByLessonAndSchoolIdAsync(double lessonId, int schoolId)
        {
            var questions = await _questionRepository.GetByLessonIdAsync(lessonId);
            var schoolQuestions = questions.Where(q => q.SchoolId == schoolId);

            foreach (var question in schoolQuestions)
            {
                await _questionRepository.DeleteAsync(question.Id);
            }

            return true;
        }

        /// <inheritdoc/>
        public async Task<int> CheckAnswersAsync(CheckAnswersRequest request)
        {
            int score = 0;

            foreach (var answer in request.Answers)
            {
                switch (answer.Type)
                {
                    case QuestionType.Regular:
                        if (answer.AnswerIds?.Count == 1)
                        {
                            var correctAnswer = await _answerRepository.GetByIdAsync(answer.AnswerIds[0]);
                            if (correctAnswer?.IsCorrect == true)
                            {
                                score++;
                            }
                        }
                        break;

                    case QuestionType.MultipleChoice:
                        if (answer.AnswerIds?.Count > 0)
                        {
                            var firstAnswer = await _answerRepository.GetByIdAsync(answer.AnswerIds[0]);
                            if (firstAnswer != null)
                            {
                                var allAnswers = await _answerRepository.GetByQuestionIdAsync(firstAnswer.QuestionId);
                                var correctAnswers = allAnswers.Where(a => a.IsCorrect).Select(a => a.Id).ToList();
                                
                                if (correctAnswers.Count == answer.AnswerIds.Count && 
                                    correctAnswers.All(id => answer.AnswerIds.Contains(id)))
                                {
                                    score++;
                                }
                            }
                        }
                        break;

                    case QuestionType.OpenEnded:
                        if (!string.IsNullOrEmpty(answer.AnswerText) && answer.AnswerIds?.Count == 1)
                        {
                            var correctAnswer = await _answerRepository.GetByIdAsync(answer.AnswerIds[0]);
                            if (correctAnswer != null)
                            {
                                var normalizedStudentAnswer = NormalizeText(answer.AnswerText);
                                if (normalizedStudentAnswer == correctAnswer.AnswerText)
                                {
                                    score++;
                                }
                            }
                        }
                        break;
                }
            }

            return score;
        }

        /// <summary>
        /// Maps a question entity and its answers to a question response model.
        /// </summary>
        /// <param name="question">The question entity to map.</param>
        /// <param name="answers">The collection of answers to map.</param>
        /// <returns>The mapped question response model.</returns>
        private static QuestionResponse MapToResponse(Question question, IEnumerable<Answer> answers)
        {
            return new QuestionResponse
            {
                Id = question.Id,
                QuestionText = question.QuestionText,
                Type = question.Type,
                LessonId = question.LessonId,
                SchoolId = question.SchoolId,
                Answers = answers.Select(a => new AnswerResponse
                {
                    Id = a.Id,
                    AnswerText = a.AnswerText,
                    IsCorrect = a.IsCorrect
                }).ToList()
            };
        }

        /// <summary>
        /// Normalizes text by converting to lowercase and removing extra whitespace.
        /// </summary>
        /// <param name="text">The text to normalize.</param>
        /// <returns>The normalized text.</returns>
        private static string NormalizeText(string text)
        {
            text = text.ToLower();
            text = text.Trim();

            return Regex.Replace(text, @"\s+", " ");
        }
    }
} 