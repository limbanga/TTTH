using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTTH.Models
{
    public class ModelScore
    {
        private int examNumber = -1;
        private int dateNumber = -1;
        private ModelClass modelClass = new ModelClass();
        private ModelStudent modelStudent = new ModelStudent();
        private double score = 0;

        public ModelScore() { } 
        public ModelScore(int examNumber, int dateNumber, ModelClass modelClass, ModelStudent modelStudent, double score)
        {
            this.ExamNumber = examNumber;
            this.DateNumber = dateNumber;
            this.ModelClass = modelClass;
            this.ModelStudent = modelStudent;
            this.Score = score;
        }

        public int ExamNumber { get => examNumber; set => examNumber = value; }
        public int DateNumber { get => dateNumber; set => dateNumber = value; }
        public ModelClass ModelClass { get => modelClass; set => modelClass = value; }
        public ModelStudent ModelStudent { get => modelStudent; set => modelStudent = value; }
        public string StudentName { get => modelStudent.Name; }
        public string StudentPhoneNumber { get => modelStudent.Name; }
        public double Score { get => score; set => score = value; }
    }
}
