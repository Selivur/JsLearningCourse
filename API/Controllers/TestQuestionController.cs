using API.Models.Question;
using API.Services.Interfaces;
using Database.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    /// <summary>
    /// Controller for managing test questions across different chapters
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
 //   [Authorize(Roles = "Admin")]
    public class TestQuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;

        public TestQuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        /// <summary>
        /// Adds questions for Chapter 1.1
        /// </summary>
        [HttpPost("add-chapter-1-1-questions")]
        public async Task<IActionResult> AddChapter1_1_Questions()
        {
            var questions = new List<CreateQuestionRequest>
            {
                new CreateQuestionRequest
                {
                    QuestionText = "У чому полягає основна відмінність між цифровим (дискретним) та аналоговим принципом обробки інформації?",
                    Type = QuestionType.Regular,
                    LessonId = 1.1,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Цифровий працює швидше за аналоговий", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Цифровий використовує цифри, а аналоговий – літери", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Цифровий оперує окремими, чітко розділеними значеннями, а аналоговий – неперервними величинами", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Аналоговий принцип є більш точним, ніж цифровий", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Як називається програма, яка аналізує весь вихідний код, переводить його в машинний код, і лише потім запускає на виконання?",
                    Type = QuestionType.OpenEnded,
                    LessonId = 1.1,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "компілятор", IsCorrect = true }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Які з перелічених компонентів входять до архітектури фон-нейманівської ЕОМ?",
                    Type = QuestionType.MultipleChoice,
                    LessonId = 1.1,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Арифметико-логічний пристрій (АЛП)", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Пристрій керування (ПК)", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Оперативна пам'ять", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Нейронна мережа", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Як називається головна плата в системному блоці, до якої під'єднуються всі основні компоненти комп'ютера?",
                    Type = QuestionType.OpenEnded,
                    LessonId = 1.1,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "материнська", IsCorrect = true }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Які переваги мають твердотільні накопичувачі (SSD) порівняно з жорсткими дисками (HDD)?",
                    Type = QuestionType.MultipleChoice,
                    LessonId = 1.1,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Більш низька вартість за гігабайт", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Висока швидкість роботи", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Відсутність рухомих частин і шуму", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Необмежена кількість циклів перезапису", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Що таке 'біт'?",
                    Type = QuestionType.Regular,
                    LessonId = 1.1,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Мінімальна одиниця інформації, що приймає значення 0 або 1", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Одиниця вимірювання швидкості процесора", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Команда для процесора", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Елемент живлення комп'ютера", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Чим відрізняється робота інтерпретатора від компілятора?",
                    Type = QuestionType.Regular,
                    LessonId = 1.1,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Інтерпретатор працює швидше", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Інтерпретатор обробляє програму по одній команді, а компілятор перекладає всю програму одразу", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Компілятор використовується для мов, близьких до машинного коду, а інтерпретатор — ні", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Немає суттєвих відмінностей", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Що є головною перевагою нейрокомп'ютерів?",
                    Type = QuestionType.Regular,
                    LessonId = 1.1,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Дешевизна компонентів", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Мала кількість потрібних нейронів", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Можливість паралельної обробки інформації та розподілена пам'ять", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Простота програмування", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Які пристрої є фізичними складовими комп'ютера?",
                    Type = QuestionType.MultipleChoice,
                    LessonId = 1.1,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Процесор (CPU)", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Оперативна пам'ять (RAM)", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Операційна система", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Жорсткий диск (HDD/SSD)", IsCorrect = true }
                    }
                }
            };

            var results = new List<QuestionResponse>();
            foreach (var question in questions)
            {
                var result = await _questionService.CreateQuestionAsync(question);
                results.Add(result);
            }

            return Ok(results);
        }

        /// <summary>
        /// Adds questions for Chapter 1.2
        /// </summary>
        [HttpPost("add-chapter-1-2-questions")]
        public async Task<IActionResult> AddChapter1_2_Questions()
        {
            var questions = new List<CreateQuestionRequest>
            {
                new CreateQuestionRequest
                {
                    QuestionText = "Як класифікують комп'ютерні мережі за територіальним охопленням?",
                    Type = QuestionType.Regular,
                    LessonId = 1.2,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Дротові та бездротові", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Локальні та глобальні", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Приватні та публічні", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Клієнтські та серверні", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Як називається всесвітня система сполучених комп'ютерних мереж, що базується на ІР-протоколах?",
                    Type = QuestionType.OpenEnded,
                    LessonId = 1.2,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Інтернет", IsCorrect = true }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "На якому принципі працює Всесвітня павутина (WWW)?",
                    Type = QuestionType.Regular,
                    LessonId = 1.2,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Виключно на передачі файлів", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Лише на обміні поштовими повідомленнями", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Клієнт-сервер", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Peer-to-peer (однорангова мережа)", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Яке програмне забезпечення використовується для взаємодії з інформацією на веб-сторінці?",
                    Type = QuestionType.OpenEnded,
                    LessonId = 1.2,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "браузер", IsCorrect = true }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Які з наведених компонентів є частиною структури URL-адреси?",
                    Type = QuestionType.MultipleChoice,
                    LessonId = 1.2,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Ім'я сервера, де розташована сторінка", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Шлях, на якому знаходиться сторінка", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Метод роботи з клієнтом і сервером (протокол)", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Розмір файлу сторінки", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Що означає термін 'гіпертекст'?",
                    Type = QuestionType.Regular,
                    LessonId = 1.2,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Текст, написаний дуже великим шрифтом", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Секретний зашифрований текст", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Текстовий документ, що містить посилання на інші ресурси", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Текст, що може містити лише зображення", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Як називається протокол передачі гіпермедійного тексту між клієнтом і сервером?",
                    Type = QuestionType.OpenEnded,
                    LessonId = 1.2,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "HTTP", IsCorrect = true }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Що є найменшою одиницею гіпертекстових даних, яку можна завантажити і прочитати за один раз?",
                    Type = QuestionType.Regular,
                    LessonId = 1.2,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Веб-сайт", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Домашня сторінка", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Веб-сторінка", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Гіперпосилання", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Що таке HTML?",
                    Type = QuestionType.MultipleChoice,
                    LessonId = 1.2,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Формат для опису вмісту та структури документа", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Мова програмування для створення серверної логіки", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Засіб для опису зв'язків з іншими документами", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Протокол передачі даних", IsCorrect = false }
                    }
                }
            };

            var results = new List<QuestionResponse>();
            foreach (var question in questions)
            {
                var result = await _questionService.CreateQuestionAsync(question);
                results.Add(result);
            }

            return Ok(results);
        }

        /// <summary>
        /// Adds questions for Chapter 1.3
        /// </summary>
        [HttpPost("add-chapter-1-3-questions")]
        public async Task<IActionResult> AddChapter1_3_Questions()
        {
            var questions = new List<CreateQuestionRequest>
            {
                new CreateQuestionRequest
                {
                    QuestionText = "Які три базові алгоритмічні конструкції є достатніми для запису алгоритму довільної складності?",
                    Type = QuestionType.MultipleChoice,
                    LessonId = 1.3,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Послідовне виконання (слідування)", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Розгалуження", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Циклічна конструкція (повторення)", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Підпрограма", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Яка властивість алгоритму означає, що він не повинен містити неоднозначних приписів і бути зрозумілим для виконавця?",
                    Type = QuestionType.Regular,
                    LessonId = 1.3,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Дискретність", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Детермінованість", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Результативність", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Зрозумілість", IsCorrect = true }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Яка різниця між 'задачею' та 'завданням'?",
                    Type = QuestionType.Regular,
                    LessonId = 1.3,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "'Задача' - це доручення, а 'завдання' - математичне питання", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "'Задача' - це переважно математичне питання, а 'завдання' - наперед визначений обсяг робіт", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Ці поняття є повними синонімами", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "'Завдання' вирішують за допомогою інструкцій, а 'задачі' - ні", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Яка геометрична фігура використовується в блок-схемах для позначення умовного виразу (розгалуження)?",
                    Type = QuestionType.OpenEnded,
                    LessonId = 1.3,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "ромб", IsCorrect = true }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Що таке 'алгоритмічно нерозв'язна задача'?",
                    Type = QuestionType.Regular,
                    LessonId = 1.3,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Дуже складна задача, на яку потрібно багато часу", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Задача, для якої неможливо в принципі побудувати єдиний універсальний алгоритм розв'язання", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Задача, яку може розв'язати лише комп'ютер, а не людина", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Задача, що не має жодного розв'язку", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Яка властивість алгоритму гарантує, що його виконання завершиться за скінченне число кроків?",
                    Type = QuestionType.OpenEnded,
                    LessonId = 1.3,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "результативність", IsCorrect = true }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Основними в загальній інформатиці є три поняття. Які з наведених до них належать?",
                    Type = QuestionType.MultipleChoice,
                    LessonId = 1.3,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Задача", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Інформація", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Алгоритм", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Програма", IsCorrect = true }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Який приклад алгоритмічно нерозв'язної проблеми наведено в тексті?",
                    Type = QuestionType.Regular,
                    LessonId = 1.3,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Задача про вовка, козу і капусту", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Десята проблема Гільберта", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Складання пірамідки з кілець", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Знаходження найбільшого спільного дільника", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Вкажіть, які з наведених тверджень про виконавців алгоритмів є вірними згідно з текстом.",
                    Type = QuestionType.MultipleChoice,
                    LessonId = 1.3,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Людина є єдиним можливим виконавцем алгоритмів", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Кожен виконавець володіє обмеженим набором допустимих дій", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Виконавці з 'біднішим' набором дій вимагають простіших алгоритмів", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Різні класи задач вимагають різних виконавців", IsCorrect = true }
                    }
                }
            };

            var results = new List<QuestionResponse>();
            foreach (var question in questions)
            {
                var result = await _questionService.CreateQuestionAsync(question);
                results.Add(result);
            }

            return Ok(results);
        }

        /// <summary>
        /// Adds questions for Chapter 1.4
        /// </summary>
        [HttpPost("add-chapter-1-4-questions")]
        public async Task<IActionResult> AddChapter1_4_Questions()
        {
            var questions = new List<CreateQuestionRequest>
            {
                new CreateQuestionRequest
                {
                    QuestionText = "Які найголовніші властивості хорошої програми виділено в тексті?",
                    Type = QuestionType.MultipleChoice,
                    LessonId = 1.4,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Коректність (правильність)", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Ефективність", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Наочність і модифікованість", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Використання найновішої мови програмування", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Чим відрізняються синтаксичні помилки від семантичних?",
                    Type = QuestionType.Regular,
                    LessonId = 1.4,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Синтаксичні помилки знайти важче, ніж семантичні", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Синтаксичні — це помилкове використання правил мови, а семантичні — помилки в логіці алгоритму", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Семантичні помилки виправляє компілятор, а синтаксичні — програміст", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Немає різниці, це синоніми", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Як називається набір ідей та рекомендацій, що визначають стиль написання програм?",
                    Type = QuestionType.OpenEnded,
                    LessonId = 1.4,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "парадигма", IsCorrect = true }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Що, за словами Дейкстри, можна довести за допомогою тестування?",
                    Type = QuestionType.Regular,
                    LessonId = 1.4,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Лише наявність помилок, але не їх відсутність", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Повну логічну правильність програми", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Ефективність програми", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Що програма буде працювати на будь-якому комп'ютері", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Які з наведених кроків входять до процесу розробки програми?",
                    Type = QuestionType.MultipleChoice,
                    LessonId = 1.4,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Розробка алгоритму", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Тестування і налагодження", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Документування програми", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Продаж програми", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Що традиційно входить до інтегрованого середовища розробки (IDE)?",
                    Type = QuestionType.MultipleChoice,
                    LessonId = 1.4,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Текстовий редактор", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Компілятор або інтерпретатор", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Відлагоджувач", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Антивірусна програма", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Як називається мова програмування, призначена для подання програм у формі, що дозволяє виконувати їх безпосередньо технічними засобами?",
                    Type = QuestionType.Regular,
                    LessonId = 1.4,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Алгоритмічна мова", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Командна мова", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Машинна мова", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Природна мова", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Яка властивість програми пов'язана з оптимальним використанням пам'яті та часових затрат?",
                    Type = QuestionType.OpenEnded,
                    LessonId = 1.4,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "ефективність", IsCorrect = true }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Чому запис алгоритму для автоматичного пристрою має бути максимально формалізованим?",
                    Type = QuestionType.Regular,
                    LessonId = 1.4,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Щоб програма виглядала складніше", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Щоб уникнути довільного тлумачення команд виконавцем", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Це вимога операційної системи", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Щоб програму було легше продати", IsCorrect = false }
                    }
                }
            };

            var results = new List<QuestionResponse>();
            foreach (var question in questions)
            {
                var result = await _questionService.CreateQuestionAsync(question);
                results.Add(result);
            }

            return Ok(results);
        }

        /// <summary>
        /// Adds questions for Chapter 1.5
        /// </summary>
        [HttpPost("add-chapter-1-5-questions")]
        public async Task<IActionResult> AddChapter1_5_Questions()
        {
            var questions = new List<CreateQuestionRequest>
            {
                new CreateQuestionRequest
                {
                    QuestionText = "У чому полягає основна відмінність між трансляцією (компіляцією) та інтерпретацією програми?",
                    Type = QuestionType.Regular,
                    LessonId = 1.5,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Інтерпретація створює виконуваний файл, а трансляція — ні", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Трансляція перекладає всю програму одразу, створюючи машинний код, а інтерпретація перекладає та виконує по одній команді", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Трансляція працює лише з мовами низького рівня, а інтерпретація — з мовами високого рівня", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Це два синоніми для одного й того ж процесу", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Які види пам'яті комп'ютера згадуються в тексті?",
                    Type = QuestionType.MultipleChoice,
                    LessonId = 1.5,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Оперативна пам'ять", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Регістрова пам'ять процесора", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Зовнішня пам'ять (на дисках чи флешках)", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Сенсорна пам'ять", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Як називаються спеціальні програми, за допомогою яких операційна система керує роботою пристроїв вводу-виведення?",
                    Type = QuestionType.OpenEnded,
                    LessonId = 1.5,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "драйвери", IsCorrect = true }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Чому перед обробкою дані, як правило, зчитуються з оперативної пам'яті в регістри процесора?",
                    Type = QuestionType.Regular,
                    LessonId = 1.5,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Бо в регістрах дані надійніше захищені", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Бо оперативна пам'ять може зберігати лише програми, а не дані", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Бо регістрова пам'ять набагато швидша за оперативну", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Це вимога операційної системи Windows", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Що визначають синтаксис та семантика оператора мови програмування?",
                    Type = QuestionType.Regular,
                    LessonId = 1.5,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Синтаксис — зміст оператора, семантика — правила його запису", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Синтаксис — правила запису оператора, семантика — його зміст (дії, які він виконує)", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Обидва терміни означають швидкість виконання оператора", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Синтаксис і семантика стосуються лише мов низького рівня", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Чим мови високого рівня (МВР) відрізняються від мов низького рівня?",
                    Type = QuestionType.Regular,
                    LessonId = 1.5,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Програми на МВР виконуються швидше", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "МВР мають вищий рівень абстракції і використовують слова, схожі на людські фрази", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "МВР не потребують перекладу на машинну мову", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Мови низького рівня є більш сучасними", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Що таке операційна система (ОС)?",
                    Type = QuestionType.Regular,
                    LessonId = 1.5,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Це будь-яка програма, що виконується на комп'ютері", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Це пристрій для підключення до мережі Інтернет", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Це набір програм для загального управління роботою комп'ютера", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Це синонім до поняття 'центральний процесор'", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "У файлі з іменем 'game.exe', що означає частина імені '.exe'?",
                    Type = QuestionType.MultipleChoice,
                    LessonId = 1.5,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Це розширення файлу", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Воно визначає тип файлу та його призначення", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Воно вказує, що файл містить машинну програму", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Це дата створення файлу", IsCorrect = false }
                    }
                }
            };

            var results = new List<QuestionResponse>();
            foreach (var question in questions)
            {
                var result = await _questionService.CreateQuestionAsync(question);
                results.Add(result);
            }

            return Ok(results);
        }

        /// <summary>
        /// Adds questions for Chapter 1.6
        /// </summary>
        [HttpPost("add-chapter-1-6-questions")]
        public async Task<IActionResult> AddChapter1_6_Questions()
        {
            var questions = new List<CreateQuestionRequest>
            {
                new CreateQuestionRequest
                {
                    QuestionText = "Як називається система числення, в якій значення кожної цифри залежить від її місця (позиції) у записі числа?",
                    Type = QuestionType.Regular,
                    LessonId = 1.6,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Римська система", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Непозиційна система", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Позиційна система", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Арабська система", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Які три способи представлення від'ємних знакових чисел описано в тексті?",
                    Type = QuestionType.MultipleChoice,
                    LessonId = 1.6,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Прямий код", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Обернений код", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Додатковий код", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Шістнадцятковий код", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Як називається процес подання неперервного сигналу (наприклад, звуку) у вигляді сукупності його окремих значень?",
                    Type = QuestionType.OpenEnded,
                    LessonId = 1.6,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "дискретизація", IsCorrect = true }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Що таке машинне слово?",
                    Type = QuestionType.Regular,
                    LessonId = 1.6,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Будь-яка команда, яку розуміє процесор", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Машиннозалежна величина пам'яті, що дорівнює розрядності регістрів процесора", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Одиниця вимірювання тактової частоти процесора", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Синонім до поняття 'байт'", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Яка система кодування кольорів, що базується на декомпозиції кольору на три основні складові, згадується в тексті?",
                    Type = QuestionType.OpenEnded,
                    LessonId = 1.6,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "rgb", IsCorrect = true }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Які переваги має кодування UTF-8, згадані у тексті?",
                    Type = QuestionType.MultipleChoice,
                    LessonId = 1.6,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Воно несумісне з ASCII", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Текст, що складається з символів з кодом < 128, перетворюється на звичайний ASCII", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Решта символів UNICODE зображуються послідовностями від 2 до 6 байтів", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Воно використовує завжди 4 байти на символ", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Як подаються дійсні числа для операцій з дуже великими або дуже маленькими значеннями?",
                    Type = QuestionType.Regular,
                    LessonId = 1.6,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "У форматі з фіксованою точкою", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "У форматі з плаваючою точкою", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Виключно у вигляді цілих чисел", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "За допомогою таблиці ASCII", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "У представленні числа з плаваючою точкою (a * 10^b), як називається частина 'a'?",
                    Type = QuestionType.OpenEnded,
                    LessonId = 1.6,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "мантиса", IsCorrect = true }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Чому для скорочення запису адрес та вмісту оперативної пам'яті використовують вісімкову та шістнадцяткову системи?",
                    Type = QuestionType.Regular,
                    LessonId = 1.6,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Тому що вони більш зрозумілі для людини, ніж десяткова", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Тому що кожні 3 двійкові розряди утворюють один вісімковий, а кожні 4 - один шістнадцятковий", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Це історична традиція, що не має технічного підґрунтя", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Тому що вони дозволяють уникнути використання цифри 0", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Що таке типізація даних у програмуванні?",
                    Type = QuestionType.Regular,
                    LessonId = 1.6,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Процес написання тексту програми", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Поділ даних на окремі групи за певною ознакою", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Перевірка програми на наявність помилок", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Процес перекладу програми на машинну мову", IsCorrect = false }
                    }
                }
            };

            var results = new List<QuestionResponse>();
            foreach (var question in questions)
            {
                var result = await _questionService.CreateQuestionAsync(question);
                results.Add(result);
            }

            return Ok(results);
        }

        /// <summary>
        /// Adds questions for Chapter 2.1
        /// </summary>
        [HttpPost("add-chapter-2-1-questions")]
        public async Task<IActionResult> AddChapter2_1_Questions()
        {
            var questions = new List<CreateQuestionRequest>
            {
                new CreateQuestionRequest
                {
                    QuestionText = "Приведіть загальну характеристику JavaScript",
                    Type = QuestionType.Regular,
                    LessonId = 2.1,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "JavaScript — це мова програмування для серверів", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "JavaScript — це компільована мова, яку використовують тільки в мобільних додатках", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "JavaScript — це мова розмітки для створення вебсторінок", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "JavaScript — це динамічна, інтерпретована мова програмування, яку зазвичай використовують у веброзробці для додавання інтерактивності", IsCorrect = true }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Яку початкову назву мала мова JavaScript?",
                    Type = QuestionType.Regular,
                    LessonId = 2.1,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Java", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "ECMAScript", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "LiveScript", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "TypeScript", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Які з перелічених переваг використання JavaScript?",
                    Type = QuestionType.MultipleChoice,
                    LessonId = 2.1,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Зменшення взаємодії з сервером для економії трафіку", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Надання прямого доступу до файлової системи користувача", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Збільшення інтерактивності сторінок", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Можливість створювати багатопотокові мережеві додатки", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Як називається офіційна специфікація (стандарт), що визначає ядро мови JavaScript?",
                    Type = QuestionType.OpenEnded,
                    LessonId = 2.1,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "ECMAScript", IsCorrect = true }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Яка команда використовується в прикладах для виведення інформації в консоль браузера?",
                    Type = QuestionType.Regular,
                    LessonId = 2.1,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "document.write()", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "alert()", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "print()", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "console.log()", IsCorrect = true }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Які способи створення коментарів у коді JavaScript описано в тексті?",
                    Type = QuestionType.MultipleChoice,
                    LessonId = 2.1,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "За допомогою символів // для однорядкового коментаря", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "За допомогою символів /* ... */ для багаторядкового коментаря", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "За допомогою символів <!-- ... -->", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "За допомогою ключового слова 'comment'", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Що станеться, якщо оголосити змінну за допомогою 'var', але не присвоїти їй значення?",
                    Type = QuestionType.Regular,
                    LessonId = 2.1,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Виникне синтаксична помилка", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Змінна отримає значення 0", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Змінна отримає спеціальне значення undefined", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Змінна отримає пустий рядок ''", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Чому клієнтський JavaScript не дозволяє читати або записувати файли на комп'ютері користувача?",
                    Type = QuestionType.Regular,
                    LessonId = 2.1,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Через технічні обмеження інтерпретатора", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "З міркувань безпеки", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Тому що для цього є мова Java", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Ця можливість з'явиться в наступних версіях", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Як називається політика безпеки, через яку вікна браузера з різних джерел не знають про існування один одного?(англіською)",
                    Type = QuestionType.OpenEnded,
                    LessonId = 2.1,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Same Origin Policy", IsCorrect = true }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Приведіть приклади використання інструкції var",
                    Type = QuestionType.MultipleChoice,
                    LessonId = 2.1,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "var name = \"Іван\";", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "var x = 10; var y = x + 5;", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "let age = 20;", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "const PI = 3.14;", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Що означає, що мова JavaScript є 'чутливою до регістру'?",
                    Type = QuestionType.Regular,
                    LessonId = 2.1,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Вона може розпізнавати мову користувача", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Вона розрізняє великі та малі літери в іменах змінних (напр., 'name' і 'Name' - це різні змінні)", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Вона автоматично виправляє регістр символів", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Всі команди потрібно писати лише у верхньому регістрі", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Що робить оператор 'for'?",
                    Type = QuestionType.Regular,
                    LessonId = 2.1,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Створює функцію", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Оголошує змінні", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Забезпечує повторне виконання блоку коду визначену кількість разів", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Перевіряє одну умову і виконує дію лише раз", IsCorrect = false }
                    }
                }
            };

            var results = new List<QuestionResponse>();
            foreach (var question in questions)
            {
                var result = await _questionService.CreateQuestionAsync(question);
                results.Add(result);
            }

            return Ok(results);
        }

        /// <summary>
        /// Adds questions for Chapter 2.2
        /// </summary>
        [HttpPost("add-chapter-2-2-questions")]
        public async Task<IActionResult> AddChapter2_2_Questions()
        {
            var questions = new List<CreateQuestionRequest>
            {
                new CreateQuestionRequest
                {
                    QuestionText = "Що є головною особливістю мови з динамічною типізацією, якою є JavaScript?",
                    Type = QuestionType.Regular,
                    LessonId = 2.2,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Тип змінної жорстко фіксується при її оголошенні і не може бути змінений", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Змінні не мають чітко фіксованого типу, і їх тип може змінюватися під час виконання програми", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Усі змінні автоматично мають числовий тип", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Перевірка типів відбувається тільки на етапі компіляції", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Які методи використовуються для додавання та видалення елементів масиву?",
                    Type = QuestionType.MultipleChoice,
                    LessonId = 2.2,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = ".push() - додає елемент в кінець масиву", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = ".shift() - видаляє перший елемент масиву", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = ".pop() - видаляє останній елемент масиву", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = ".length - додає елемент в масив", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Який метод об'єкта Math використовується для генерації випадкового числа від 0 до 1?(Тільки назву)",
                    Type = QuestionType.OpenEnded,
                    LessonId = 2.2,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "random()", IsCorrect = true }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "У чому полягає різниця між операторами порівняння '==' та '==='?",
                    Type = QuestionType.Regular,
                    LessonId = 2.2,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Різниці немає, це синоніми", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "'===' порівнює значення без перетворення типів, а '==' виконує перетворення типів перед порівнянням", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "'==' порівнює лише числа, а '===' - лише рядки", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "'===' є оператором присвоєння, а '==' - оператором порівняння", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Які з перелічених типів даних у JavaScript є примітивними?",
                    Type = QuestionType.MultipleChoice,
                    LessonId = 2.2,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Числовий (Number)", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Рядковий (String)", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Об'єктний (Object)", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Логічний (Boolean)", IsCorrect = true }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Яка властивість використовується для отримання кількості символів у рядку або кількості елементів у масиві?",
                    Type = QuestionType.OpenEnded,
                    LessonId = 2.2,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "length", IsCorrect = true }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Згідно з правилами перетворення типів у JavaScript, які значення перетворюються на 'false'?",
                    Type = QuestionType.MultipleChoice,
                    LessonId = 2.2,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "0", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Порожній рядок ''", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "undefined", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Будь-яке число, крім нуля", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Як можна отримати доступ до значення властивості 'name' в об'єкті 'user'?",
                    Type = QuestionType.Regular,
                    LessonId = 2.2,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Тільки як user(name)", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Тільки як user[name]", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "За допомогою 'точкової нотації' user.name або 'дужкової нотації' user['name']", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Через функцію get(user, name)", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Що робить оператор '%' (відсоток) у JavaScript?",
                    Type = QuestionType.Regular,
                    LessonId = 2.2,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Обчислює відсоток від числа", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Повертає залишок від ділення націло", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Виконує ділення з плаваючою точкою", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Перетворює число на рядок", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Чим відрізняється спеціальне значення 'null' від 'undefined'?",
                    Type = QuestionType.Regular,
                    LessonId = 2.2,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "'undefined' означає 'значення не присвоєно', а 'null' — це явна вказівка на 'відсутність значення'", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Це повні синоніми, між ними немає різниці", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "'null' використовується для чисел, а 'undefined' — для рядків", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "'null' означає помилку, а 'undefined' — успішне завершення", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Як називається метод, що дозволяє вирізати частину рядка, вказавши початковий та кінцевий індекси?",
                    Type = QuestionType.OpenEnded,
                    LessonId = 2.2,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = ".slice()", IsCorrect = true }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Чим об'єкт у JavaScript відрізняється від масиву?",
                    Type = QuestionType.Regular,
                    LessonId = 2.2,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Об'єкти впорядковані, а масиви — ні", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Для доступу до елементів об'єкта використовуються рядкові ключі, а до елементів масиву — числові індекси", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Масиви можуть зберігати дані різних типів, а об'єкти — тільки одного", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Об'єкти створюються за допомогою [], а масиви — за допомогою {}", IsCorrect = false }
                    }
                }
            };

            var results = new List<QuestionResponse>();
            foreach (var question in questions)
            {
                var result = await _questionService.CreateQuestionAsync(question);
                results.Add(result);
            }

            return Ok(results);
        }

        /// <summary>
        /// Adds questions for Chapter 2.3
        /// </summary>
        [HttpPost("add-chapter-2-3-questions")]
        public async Task<IActionResult> AddChapter2_3_Questions()
        {
            var questions = new List<CreateQuestionRequest>
            {
                new CreateQuestionRequest
                {
                    QuestionText = "Яка ключова відмінність між циклами 'while' та 'do/while'?",
                    Type = QuestionType.Regular,
                    LessonId = 2.3,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "'while' виконується швидше, ніж 'do/while'", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Тіло циклу 'do/while' виконається хоча б один раз, тоді як тіло 'while' може не виконатись жодного разу", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Цикл 'while' перевіряє умову після виконання тіла, а 'do/while' — до", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Між ними немає суттєвої різниці", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Які є оператори циклу?",
                    Type = QuestionType.MultipleChoice,
                    LessonId = 2.3,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "for", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "while", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "if", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "do/while", IsCorrect = true }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Який оператор використовується для негайного виходу з циклу або конструкції switch?",
                    Type = QuestionType.OpenEnded,
                    LessonId = 2.3,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "break", IsCorrect = true }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Для чого призначений оператор 'switch'?",
                    Type = QuestionType.Regular,
                    LessonId = 2.3,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Для створення нескінченних циклів", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Для вибору одного з багатьох блоків коду для виконання на основі одного значення", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Для об'єднання кількох операторів у групу", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Це альтернативний синтаксис для оператора 'if-else'", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Що означають три частини в заголовку циклу 'for(A; B; C)'?",
                    Type = QuestionType.Regular,
                    LessonId = 2.3,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "A - умова, B - ініціалізація, C - інкремент", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "A - ініціалізація, B - умова, C - інкремент", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "A - інкремент, B - умова, C - ініціалізація", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "A - умова, B - інкремент, C - тіло циклу", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Який оператор використовується для пропуску поточної ітерації циклу та переходу до наступної?",
                    Type = QuestionType.OpenEnded,
                    LessonId = 2.3,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "continue", IsCorrect = true }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Що поверне функція 'confirm', якщо користувач натисне кнопку 'Відміна' або клавішу Esc?",
                    Type = QuestionType.Regular,
                    LessonId = 2.3,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "true", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "false", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "undefined", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "null", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Який синтаксис має тернарний оператор, що є скороченою формою для 'if-else'?",
                    Type = QuestionType.Regular,
                    LessonId = 2.3,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "(умова) : оператор1 ? оператор2", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "if (умова) then оператор1 else оператор2", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "(умова) ? оператор1 : оператор2", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "switch (умова) { ? оператор1; : оператор2; }", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Які символи використовуються для групування кількох JavaScript операторів в один блок?",
                    Type = QuestionType.OpenEnded,
                    LessonId = 2.3,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "{}", IsCorrect = true }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Що станеться, якщо у конструкції 'switch' пропустити оператор 'break' після одного з блоків 'case'?",
                    Type = QuestionType.Regular,
                    LessonId = 2.3,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Виникне синтаксична помилка", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Виконання 'провалиться' до наступного блоку 'case' і буде виконувати його код", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Конструкція 'switch' завершить свою роботу", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Виконається блок 'default'", IsCorrect = false }
                    }
                }
            };
            var results = new List<QuestionResponse>();
            foreach (var question in questions)
            {
                var result = await _questionService.CreateQuestionAsync(question);
                results.Add(result);
            }

            return Ok(results);
        }

        [HttpPost("add-chapter-2-4-questions")]
        public async Task<IActionResult> AddChapter2_4_Questions()
        {
           var questions = new List<CreateQuestionRequest>
            {
                new CreateQuestionRequest
                {
                    QuestionText = "Що таке рекурсія в програмуванні?",
                    Type = QuestionType.Regular,
                    LessonId = 2.4,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Використання циклу for всередині циклу while", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Виклик функції з неї ж самої, безпосередньо або через інші функції", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Процес налагодження програми за допомогою відлагоджувача", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Оголошення змінної всередині функції", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Які дві обов'язкові структурні частини повинна мати рекурсивна функція, щоб уникнути нескінченного виконання?",
                    Type = QuestionType.MultipleChoice,
                    LessonId = 2.4,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Рекурсивна гілка (крок)", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Термінальна гілка (умова припинення рекурсії)", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Глобальна змінна", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Оператор циклу", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Що поверне функція JavaScript, якщо в її тілі відсутня інструкція 'return'?",
                    Type = QuestionType.OpenEnded,
                    LessonId = 2.4,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "undefined", IsCorrect = true }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "У чому полягає різниця між формальними та фактичними параметрами функції?",
                    Type = QuestionType.Regular,
                    LessonId = 2.4,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Різниці немає, це синоніми", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Формальні параметри вказуються при виклику функції, а фактичні — при її визначенні", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Формальні параметри — це імена у визначенні функції, а фактичні — це значення, що передаються при її виклику", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Фактичні параметри завжди є числами, а формальні — рядками", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Який метод розробки програм, що полягає у розбитті складної задачі на простіші підзадачі, описано в тексті?",
                    Type = QuestionType.OpenEnded,
                    LessonId = 2.4,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Декомпозиція", IsCorrect = true }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Що таке 'функціональний літерал'?",
                    Type = QuestionType.Regular,
                    LessonId = 2.4,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Це коментар, що описує функцію", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Це спосіб визначення функції, коли вона присвоюється змінній (напр., var myFunc = function(){...})", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Це будь-яка вбудована функція JavaScript, наприклад alert()", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Це спеціальний оператор для виклику функції", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Які переваги забезпечує проектування методом 'зверху-донизу' з використанням підпрограм?",
                    Type = QuestionType.MultipleChoice,
                    LessonId = 2.4,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Скорочення часу розробки", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Оптимізація процесу відлагодження програми", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Завжди гарантує відсутність помилок у програмі", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Відносна автономність модифікації коду", IsCorrect = true }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Що станеться в JavaScript, якщо викликати функцію з меншою кількістю аргументів, ніж зазначено у її визначенні?",
                    Type = QuestionType.Regular,
                    LessonId = 2.4,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Виникне синтаксична помилка", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Відсутнім параметрам буде присвоєно значення 'undefined'", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Відсутнім параметрам буде присвоєно значення 'null'", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Функція не буде виконана", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Як називаються змінні, оголошені поза всіма функціями і видимі для будь-якої функції в програмі?",
                    Type = QuestionType.OpenEnded,
                    LessonId = 2.4,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Глобальними", IsCorrect = true }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Який механізм або структура даних використовується для реалізації рекурсивних викликів функцій?",
                    Type = QuestionType.Regular,
                    LessonId = 2.4,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Масив", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Об'єкт", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Стек викликів", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Глобальна змінна", IsCorrect = false }
                    }
                }
            };

            var results = new List<QuestionResponse>();
            foreach (var question in questions)
            {
                var result = await _questionService.CreateQuestionAsync(question);
                results.Add(result);
            }

            return Ok(results);
        }

        [HttpPost("add-chapter-2-5-questions")]
        public async Task<IActionResult> AddChapter2_5_Questions()
        {
            var questions = new List<CreateQuestionRequest>
            {
                new CreateQuestionRequest
                {
                    QuestionText = "Яка ключова характеристика програмного фреймворку відрізняє його від бібліотеки?",
                    Type = QuestionType.Regular,
                    LessonId = 2.5,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Фреймворк завжди менший за розміром, ніж бібліотека", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Інверсія управління, коли фреймворк викликає код застосунку, а не навпаки", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Бібліотеки використовуються для веб-розробки, а фреймворки — для настільних додатків", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Фреймворк не може містити в собі бібліотеки", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "В яких сферах, окрім веб-сторінок, активно використовується JavaScript згідно з текстом?",
                    Type = QuestionType.MultipleChoice,
                    LessonId = 2.5,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Розробка бекенду (серверної частини)", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Розробка настільних додатків (GUI)", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Розробка мобільних застосунків", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Тільки для маніпуляцій з DOM", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Як називається середовище виконання, що дозволило виконувати код JavaScript поза браузером?",
                    Type = QuestionType.OpenEnded,
                    LessonId = 2.5,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Node.js", IsCorrect = true }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Що таке DOM (Об'єктна модель документа)?",
                    Type = QuestionType.Regular,
                    LessonId = 2.5,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Це мова програмування, схожа на JavaScript", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Це специфікація програмного інтерфейсу для роботи зі структурованими документами, як-от HTML", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Це бібліотека для створення анімацій", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Це назва першого веб-браузера", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Яка бібліотека зробила революцію, уніфікувавши методи для DOM маніпуляцій у різних браузерах?",
                    Type = QuestionType.OpenEnded,
                    LessonId = 2.5,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "jQuery", IsCorrect = true }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Яка головна перевага неблокуючої моделі введення/виводу в Node.js?",
                    Type = QuestionType.Regular,
                    LessonId = 2.5,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Вона дозволяє писати менше коду", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Вона забезпечує вищий рівень безпеки", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Вона дає можливість обробляти велику кількість одночасних запитів в одному потоці", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Вона працює тільки з базами даних", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Які з цих відомих додатків створені з використанням JavaScript для настільних комп'ютерів?",
                    Type = QuestionType.MultipleChoice,
                    LessonId = 2.5,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Microsoft Visual Studio Code", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "WhatsApp Desktop", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Adobe Photoshop (основний додаток)", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Facebook Messenger Desktop", IsCorrect = true }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Як називається користувацька комп'ютерна програма, що дає змогу вирішувати конкретні прикладні задачі?",
                    Type = QuestionType.OpenEnded,
                    LessonId = 2.5,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "застосунок", IsCorrect = true }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Які проблеми мали перші монолітні фреймворки?",
                    Type = QuestionType.Regular,
                    LessonId = 2.5,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Вони були занадто малими і не мали достатньої функціональності", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Внесення змін у невелику частину вимагало повторного тестування і випуску всього фреймворку", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Вони не підтримували бібліотеки", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Вони не мали інверсії управління", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Що таке інтерфейс командного рядка (CLI)?",
                    Type = QuestionType.Regular,
                    LessonId = 2.5,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Графічний інтерфейс з іконками та вікнами", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Різновид текстового інтерфейсу, де команди даються шляхом вводу текстових стрічок", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Інтерфейс для керування мобільними пристроями", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Спеціалізований інтерфейс для роботи з базами даних", IsCorrect = false }
                    }
                }
            };

            var results = new List<QuestionResponse>();
            foreach (var question in questions)
            {
                var result = await _questionService.CreateQuestionAsync(question);
                results.Add(result);
            }

            return Ok(results);
        }

        [HttpPost("add-chapter-2-6-questions")]
        public async Task<IActionResult> AddChapter2_6_Questions()
        {
            var questions = new List<CreateQuestionRequest>
            {
                new CreateQuestionRequest
                {
                    QuestionText = "Яка фундаментальна відмінність механізму успадкування в JavaScript від класичних ООП мов, як-от Java?",
                    Type = QuestionType.Regular,
                    LessonId = 2.6,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "У JavaScript успадкування відсутнє", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "У JavaScript успадкування відбувається шляхом клонування існуючого об'єкта-прототипу, а в Java — через ієрархію класів", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "У JavaScript можна успадковувати лише властивості, але не методи", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Механізми повністю ідентичні", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Які три аспекти, згідно з висновками, забезпечують унікальність та конкурентоспроможність JavaScript?",
                    Type = QuestionType.MultipleChoice,
                    LessonId = 2.6,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Повна інтеграція з браузером", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Простий синтаксис для простих речей", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Підтримка майже скрізь", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Найвища швидкість виконання серед усіх мов", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Яка спеціальна властивість в об'єкті JavaScript містить посилання на його прототип?",
                    Type = QuestionType.OpenEnded,
                    LessonId = 2.6,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "__proto__", IsCorrect = true }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Що таке скрипт (сценарій)?",
                    Type = QuestionType.Regular,
                    LessonId = 2.6,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Будь-яка програма, написана на мові низького рівня", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Програма або програмний файл, що автоматизує задачу, яку користувач робив би вручну", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Програма, що працює виключно на сервері", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Текстовий файл, що містить документацію до програми", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "В якому порядку відбувається пошук властивості в об'єкті, що має прототип?",
                    Type = QuestionType.Regular,
                    LessonId = 2.6,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Спочатку в прототипі, потім у самому об'єкті", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Пошук відбувається одночасно в об'єкті та його прототипі", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Спочатку в самому об'єкті, і якщо властивість не знайдена — пошук продовжується в його прототипі", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Пошук відбувається тільки у властивостях самого об'єкта", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Як у JavaScript називають функцію(метод), що використовується для створення нових об'єктів за допомогою ключового слова 'new'?",
                    Type = QuestionType.OpenEnded,
                    LessonId = 2.6,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "конструктор", IsCorrect = true }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Який цикл перебирає як власні, так і успадковані властивості об'єкта?",
                    Type = QuestionType.Regular,
                    LessonId = 2.6,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "for...of", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "while", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "for...in", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "do...while", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Який вбудований метод об'єкта дозволяє перевірити, чи належить властивість самому об'єкту, а не його прототипу?",
                    Type = QuestionType.OpenEnded,
                    LessonId = 2.6,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "hasOwnProperty", IsCorrect = true }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Що відбувається, коли ви намагаєтесь записати значення у властивість, яка існує в прототипі, але відсутня в самому об'єкті?",
                    Type = QuestionType.Regular,
                    LessonId = 2.6,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Значення записується у властивість прототипу", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Створюється нова власна властивість в самому об'єкті з таким же іменем", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Виникає помилка, оскільки не можна змінювати успадковані властивості", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Нічого не відбувається", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Чому примітивні типи даних, як-от рядки та числа, мають методи (наприклад, .length або .toString())?",
                    Type = QuestionType.Regular,
                    LessonId = 2.6,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Тому що вони насправді є об'єктами", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Тому що при спробі доступу до їх властивостей створюється тимчасовий об'єкт-обгортка", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Це глобальні функції, які можна застосувати до будь-якого типу даних", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Це помилка в тексті, примітивні типи не мають методів", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Що таке \"інтроспекція\" у JavaScript?",
                    Type = QuestionType.Regular,
                    LessonId = 2.6,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Процес стискання коду для оптимізації виконання", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Можливість приховати код від користувача", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Можливість визначити тип і структуру об'єкта під час виконання програми", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Метод створення прототипів об'єктів", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Яка структура робить JavaScript особливо зручним для створення інтерактивних елементів?",
                    Type = QuestionType.Regular,
                    LessonId = 2.6,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Модель процесу", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Модель мови CSS", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Об'єктна модель документа (DOM)", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Модель компіляції", IsCorrect = false }
                    }
                },
            };

            var results = new List<QuestionResponse>();
            foreach (var question in questions)
            {
                var result = await _questionService.CreateQuestionAsync(question);
                results.Add(result);
            }

            return Ok(results);
        }
        [HttpPost("add-chapter-3-1-questions")]
        public async Task<IActionResult> AddChapter3_1_Questions()
        {
            var questions = new List<CreateQuestionRequest>
            {
                new CreateQuestionRequest
                {
                    QuestionText = "У чому полягає головна відмінність між серверними та клієнтськими скриптами?",
                    Type = QuestionType.Regular,
                    LessonId = 3.1,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Серверні скрипти пишуться на PHP, а клієнтські — тільки на JavaScript", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Клієнтські скрипти працюють швидше за серверні", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Серверні виконуються на сервері до завантаження сторінки, а клієнтські — у браузері користувача після завантаження", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Немає суттєвої різниці, обидва виконуються у браузері", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Які технології є мінімальним набором знань для початківця у веб-програмуванні?",
                    Type = QuestionType.MultipleChoice,
                    LessonId = 3.1,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "HTML", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "PHP", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "JavaScript", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "MySQL", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Яка технологія від Microsoft є повною платформою для веб-розробки, але за її використання потрібно платити?",
                    Type = QuestionType.OpenEnded,
                    LessonId = 3.1,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "ASP.NET", IsCorrect = true }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Яка технологія є базовим інструментом у веб-дизайні для компоновки сторінок та їх декорування?",
                    Type = QuestionType.Regular,
                    LessonId = 3.1,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "HTML", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "CSS", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "JavaScript", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "PHP", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Яка мова веб-програмування серверних скриптів виділяється простотою і можливістю вставляти її код безпосередньо в HTML?",
                    Type = QuestionType.Regular,
                    LessonId = 3.1,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Perl", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Javascript", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "PHP", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Flash", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Які з наведених можливостей є прикладами інтерактивної взаємодії, яку оптимізує веб-розробник?",
                    Type = QuestionType.MultipleChoice,
                    LessonId = 3.1,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Засоби зворотного зв'язку (реєстрація)", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Система керування сайтом (CMS)", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Швидкість інтернет-з'єднання користувача", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Пошук по сайту", IsCorrect = true }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Що таке клієнт-серверна взаємодія?",
                    Type = QuestionType.Regular,
                    LessonId = 3.1,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Коли два клієнти обмінюються даними напряму", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Коли клієнт робить запит до сервера, а сервер повертає відповідь", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Коли сервер запитує дані у клієнта", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Коли всі обчислення відбуваються лише на стороні клієнта", IsCorrect = false }
                    }
                }
            };

            var results = new List<QuestionResponse>();
            foreach (var question in questions)
            {
                var result = await _questionService.CreateQuestionAsync(question);
                results.Add(result);
            }

            return Ok(results);
        }
        [HttpPost("add-chapter-3-3-questions")]
        public async Task<IActionResult> AddChapter3_3_Questions()
        {
            var questions = new List<CreateQuestionRequest>
            {
                new CreateQuestionRequest
                {
                    QuestionText = "Які дві функції для роботи з рядками використовуються в прикладі анімації тексту для зміни регістру літер?",
                    Type = QuestionType.MultipleChoice,
                    LessonId = 3.3,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "toUpperCase()", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "toLowerCase()", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "changeCase()", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "stringCase()", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Яка подія використовується для запуску функції годинника, щойно завантажиться тіло HTML-документа?",
                    Type = QuestionType.OpenEnded,
                    LessonId = 3.3,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "onload", IsCorrect = true }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "У прикладі створення Drag&Drop, яка властивість CSS встановлюється для елемента, щоб його можна було позиціонувати в будь-якому місці документа?",
                    Type = QuestionType.Regular,
                    LessonId = 3.3,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "display: block;", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "position: absolute;", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "float: left;", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "visibility: visible;", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Яка функція використовується для періодичного повторного виклику функції анімації?",
                    Type = QuestionType.OpenEnded,
                    LessonId = 3.3,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "setTimeout()", IsCorrect = true }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Які три основні події миші використовуються для реалізації функціоналу Drag&Drop?",
                    Type = QuestionType.MultipleChoice,
                    LessonId = 3.3,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "onclick", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "onmousedown", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "onmousemove", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "onmouseup", IsCorrect = true }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "У прикладі з календарем, який об'єкт створюється для отримання поточної дати?",
                    Type = QuestionType.Regular,
                    LessonId = 3.3,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "new Calendar()", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "new Time()", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "new Date()", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "new SystemDate()", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Як називається функція для отримання частини рядка із зазначенням початкового та кінцевого індексів, що використовується в анімації тексту?",
                    Type = QuestionType.OpenEnded,
                    LessonId = 3.3,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "substring()", IsCorrect = true }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Що робить властивість 'zIndex' у прикладі з перетягуванням м'яча?",
                    Type = QuestionType.Regular,
                    LessonId = 3.3,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Змінює розмір об'єкта", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Визначає, який з об'єктів буде відображатись поверх іншого", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Робить об'єкт прозорим", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Забороняє перетягування об'єкта", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "У прикладі з годинником, як з десяткового числа (напр. 12) отримують окремі цифри для відображення?",
                    Type = QuestionType.Regular,
                    LessonId = 3.3,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "За допомогою спеціальної функції getDigits()", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "За допомогою ділення на 10 для отримання першої цифри та взяття залишку від ділення на 10 для другої", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Шляхом перетворення числа в рядок і взяття символів за індексом", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Це неможливо зробити стандартними засобами", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Яку функцію в прикладі з календарем використовують для динамічного додавання HTML-коду (картинок) на сторінку?",
                    Type = QuestionType.OpenEnded,
                    LessonId = 3.3,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "write()", IsCorrect = true }
                    }
                }
            };

            var results = new List<QuestionResponse>();
            foreach (var question in questions)
            {
                var result = await _questionService.CreateQuestionAsync(question);
                results.Add(result);
            }

            return Ok(results);
        }
        [HttpPost("add-chapter-3-4-questions")]
        public async Task<IActionResult> AddChapter3_4_Questions()
        {
            var questions = new List<CreateQuestionRequest>
            {
                new CreateQuestionRequest
                {
                    QuestionText = "Яка основна мета використання CSS (Каскадних таблиць стилів)?",
                    Type = QuestionType.Regular,
                    LessonId = 3.4,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Для створення структури та вмісту веб-сторінки", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Для відокремлення візуального оформлення документа від його структури (HTML)", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Для написання серверної логіки та взаємодії з базами даних", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Для додавання інтерактивності та анімації на сторінку", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Які способи підключення CSS до HTML-документа описані в тексті?",
                    Type = QuestionType.MultipleChoice,
                    LessonId = 3.4,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Зовнішня таблиця стилів за допомогою тегу <link>", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Внутрішня таблиця стилів усередині тегу <style>", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Вбудований стиль за допомогою атрибута style в HTML-тезі", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Через JavaScript функцію loadCSS()", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Як називається частина CSS-правила, що вибирає елемент, до якого будуть застосовані стилі?",
                    Type = QuestionType.OpenEnded,
                    LessonId = 3.4,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "селектор", IsCorrect = true }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Який селектор використовується для застосування стилю до одного унікального елемента на сторінці?",
                    Type = QuestionType.Regular,
                    LessonId = 3.4,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Селектор класів (.classname)", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Селектор елементів (p)", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Селектор ідентифікаторів (#idname)", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Універсальний селектор (*)", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Згідно з правилами каскадності, який стиль матиме найвищий пріоритет?",
                    Type = QuestionType.Regular,
                    LessonId = 3.4,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Зовнішня таблиця стилів", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Внутрішня таблиця стилів", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Стиль, що розташовується в рамках самого елемента (вбудований)", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Стиль, оголошений як '!important'", IsCorrect = true }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Що таке псевдоклас у CSS?",
                    Type = QuestionType.Regular,
                    LessonId = 3.4,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Ключове слово, що додається до селектора, щоб стилізувати елемент в певному стані (напр., :hover)", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Спосіб вибрати перший або останній елемент у списку", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Синонім до селектора класів", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Властивість, яка робить елемент невидимим", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Що робить комбінатор ' > ' (наприклад, 'div > p')?",
                    Type = QuestionType.Regular,
                    LessonId = 3.4,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Вибирає всі елементи <p>, які є нащадками <div> будь-якої глибини", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Вибирає всі елементи <p>, які знаходяться на одному рівні з <div>", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Вибирає тільки ті елементи <p>, які є безпосередніми нащадками <div>", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Вибирає елемент <p>, який іде відразу після <div>", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Що відбувається з CSS-правилом, якщо браузер не розпізнає одну з властивостей або її значення?",
                    Type = QuestionType.Regular,
                    LessonId = 3.4,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Вся таблиця стилів перестає працювати", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Все правило, в якому міститься помилка, ігнорується", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Тільки нерозпізнане оголошення (властивість:значення) ігнорується", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Браузер показує повідомлення про помилку", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Які з цих одиниць виміру в CSS є абсолютними?",
                    Type = QuestionType.MultipleChoice,
                    LessonId = 3.4,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "px", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "pt", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "%", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "cm", IsCorrect = true }
                    }
                }
            };

            var results = new List<QuestionResponse>();
            foreach (var question in questions)
            {
                var result = await _questionService.CreateQuestionAsync(question);
                results.Add(result);
            }

            return Ok(results);
        }

        [HttpPost("add-chapter-3-5-questions")]
        public async Task<IActionResult> AddChapter3_5_Questions()
        {
            var questions = new List<CreateQuestionRequest>
            {
                new CreateQuestionRequest
                {
                    QuestionText = "Яка ключова і найчастіше використовувана функція в бібліотеці jQuery?",
                    Type = QuestionType.Regular,
                    LessonId = 3.5,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "jQuery.ajax()", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "$()", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = ".ready()", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = ".click()", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Які з цих селекторів є специфічними для jQuery, а не стандартними для CSS?",
                    Type = QuestionType.MultipleChoice,
                    LessonId = 3.5,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = ":even", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = ":has(a)", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "#myId", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = ":visible", IsCorrect = true }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Яка основна відмінність між обробниками готовності документа $(window).load() та $(document).ready()?",
                    Type = QuestionType.Regular,
                    LessonId = 3.5,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Жодної різниці немає", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "$(window).load() чекає завантаження лише структури документа (DOM), а $(document).ready() чекає завантаження всього контенту, включаючи зображення", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "$(document).ready() чекає завантаження лише структури документа (DOM), а $(window).load() чекає завантаження всього контенту, включаючи зображення", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "$(document).ready() працює швидше за всіх умов", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Який метод jQuery використовується для додавання нового елемента в кінець дочірніх елементів вибраного об'єкта?",
                    Type = QuestionType.OpenEnded,
                    LessonId = 3.5,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Append()", IsCorrect = true }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Що робить метод jQuery .toggleClass('myClass')?",
                    Type = QuestionType.Regular,
                    LessonId = 3.5,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Завжди додає клас 'myClass' до елемента", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Завжди видаляє клас 'myClass' з елемента", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Додає клас 'myClass', якщо його немає, або видаляє, якщо він є", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Перевіряє, чи має елемент клас 'myClass'", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Які переваги використання jQuery над чистим JavaScript згадуються в тексті?",
                    Type = QuestionType.MultipleChoice,
                    LessonId = 3.5,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Менший обсяг програмного коду", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Код більш зрозумілий", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Згладжування кросбраузерних відмінностей", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Вища швидкість виконання будь-якого коду", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Для чого використовується технологія JSONP?",
                    Type = QuestionType.Regular,
                    LessonId = 3.5,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Для стилізації сторінок замість CSS", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Для отримання JSON-даних із зовнішнього домену, обходячи політику однакового походження", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Для створення анімації", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Для валідації HTML-коду", IsCorrect = false }
                    }
                },
                new CreateQuestionRequest
                {
                    QuestionText = "Що означає селектор $('tr:nth-child(odd)') в jQuery?",
                    Type = QuestionType.Regular,
                    LessonId = 3.5,
                    SchoolId = 0,
                    Answers = new List<CreateAnswerRequest>
                    {
                        new CreateAnswerRequest { AnswerText = "Вибирає всі рядки таблиці", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Вибирає перший рядок таблиці", IsCorrect = false },
                        new CreateAnswerRequest { AnswerText = "Вибирає непарні рядки таблиці", IsCorrect = true },
                        new CreateAnswerRequest { AnswerText = "Вибирає третій рядок таблиці", IsCorrect = false }
                    }
                }
            };

            var results = new List<QuestionResponse>();
            foreach (var question in questions)
            {
                var result = await _questionService.CreateQuestionAsync(question);
                results.Add(result);
            }

            return Ok(results);
        }

    }
} 