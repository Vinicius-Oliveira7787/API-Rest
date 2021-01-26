namespace Domain.Exams
{
    public class ExamsService  {
        

        public bool AnswerQuestions(List<string> aswers) {
            if (Aswers != null || aswers == null) {
                return false;
            }

            for (int i = 0; i < aswers.Count; i++) {
                Aswers[i] = aswers[i];
            }

            return true;
        }

        public int CheckCorrectAswers() {
            int CorrectAswersCounter = 0;

            for (int i = 0; i < Questions.Count; i++)
            {
                if (Questions[i] == Aswers[i])
                {
                    CorrectAswersCounter++;
                }
            }
            
            
            Score = GenerateScore(CorrectAswersCounter);
            return CorrectAswersCounter;
        }

        private double GenerateScore(int correctAswersCounter) {
            int amountOfQuestions = Questions.Count;
            return correctAswersCounter / amountOfQuestions;
        }
    }
}