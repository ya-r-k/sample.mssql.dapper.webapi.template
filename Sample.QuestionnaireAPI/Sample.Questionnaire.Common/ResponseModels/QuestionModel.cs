﻿using Sample.Questionnaire.Common.Enums;

namespace Sample.Questionnaire.Common.ResponseModels;

public class QuestionModel
{
    public long Id { get; set; }

    public string Text { get; set; }

    public QuestionType Type { get; set; }

    public int Complexity { get; set; }

    public IEnumerable<QuestionOptionModel> Options { get; set; }
}
