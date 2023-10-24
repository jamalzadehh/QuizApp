namespace ConsoleApp1
{
    class Program
    {
        static List<Quiz> quizzes = new List<Quiz>();
        static int quizId = 0;
        static int questionId = 0;

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1. Sual yarat:");
                Console.WriteLine("2. Suali hell et:");
                Console.WriteLine("3. Suallari goster:");
                Console.WriteLine("0. Cixish");
                Console.Write("Seciminiz:: ");
                int choice;

                try
                {
                    choice = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        CreateQuiz();
                        break;
                    case 2:
                        SolveQuiz();
                        break;
                    case 3:
                        ShowQuizzes();
                        break;
                    case 0:
                        Console.WriteLine("Cixish:");
                        return;
                    default:
                        Console.WriteLine("Yanlish secim.");
                        break;
                }
            }
        }

        static void CreateQuiz()
        {
            Quiz newQuiz = new Quiz();
            newQuiz.Id = ++quizId;

            Console.Write("Sualin adini daxil et: ");
            newQuiz.Name = Console.ReadLine();

            Console.Write("Sualin nomresini daxil et: ");
            int numQuestions;

            try
            {
                numQuestions = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Yanlish deyer.");
                return;
            }

            for (int i = 0; i < numQuestions; i++)
            {
                Question newQuestion = new Question();
                newQuestion.Id = ++questionId;

                Console.Write("Sualin metnini daxil e: ");
                newQuestion.Text = Console.ReadLine();

                Console.Write("Variaantlari daxil et: ");
                int numVariants;

                try
                {
                    numVariants = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Yanlish deyer:");
                    return;
                }

                for (int j = 0; j < numVariants; j++)
                {
                    Console.Write($"Variant daxil et {j + 1}: ");
                    newQuestion.Variants.Add(Console.ReadLine());
                }

                Console.Write("Duzgun variantin nomresi: ");
                int correctVariant;

                try
                {
                    correctVariant = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Yanlish deyer.");
                    return;
                }

                if (correctVariant < 1 || correctVariant > numVariants)
                {
                    Console.WriteLine("Yanlish deyer:");
                    return;
                }

                newQuestion.CorrectVariant = correctVariant;

                newQuiz.Questions.Add(newQuestion);
            }

            quizzes.Add(newQuiz);
        }

        static void SolveQuiz()
        {
            Console.Write("Sualin ID ni daixl et: ");
            int solvedQuizId;

            try
            {
                solvedQuizId = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("YAnlish secim:");
                return;
            }

            Quiz solvedQuiz = quizzes.Find(q => q.Id == solvedQuizId);

            if (solvedQuiz == null)
            {
                Console.WriteLine("Quiz tapilmadi1");
                return;
            }

            int correctAnswers = 0;

            foreach (var question in solvedQuiz.Questions)
            {
                Console.WriteLine(question.Text);
                for (int i = 0; i < question.Variants.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {question.Variants[i]}");
                }

                Console.Write("Cavabiniz: ");
                int answer;

                try
                {
                    answer = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Yanlish deyer:");
                    return;
                }

                if (answer < 1 || answer > question.Variants.Count)
                {
                    Console.WriteLine("YAnlish deyer:");
                    return;
                }

                if (answer == question.CorrectVariant)
                {
                    correctAnswers++;
                }
            }
            Console.WriteLine($"{solvedQuiz.Questions.Count} sualinadn {correctAnswers} duz cavab verdiniz.");
        }
        static void ShowQuizzes()
        {
            foreach (var quiz in quizzes)
            {
                Console.WriteLine($"Id: {quiz.Id}, Name: {quiz.Name}");
            }
        }
    }
}