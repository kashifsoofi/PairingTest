﻿using System.Collections.Generic;
using System.Runtime.Serialization;

namespace QuestionServiceWebApi
{
    [DataContract]
    public class Questionnaire
    {
        [DataMember]
        public string QuestionnaireTitle { get; set; }
        [DataMember]
        public IList<string> QuestionsText { get; set; }
        [DataMember]
        public IList<string> AnswersText { get; set; }
        [DataMember]
        public IList<int> CorrectAnswers { get; set; }
    }
}