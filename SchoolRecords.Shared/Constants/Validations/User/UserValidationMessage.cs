﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolRecords.Shared.Constants.Validations.User
{
    public static class UserValidationMessage
    {
        public static string BIRTH_DATE_GREATER_THAN_TODAY = "A data de nascimento não pode ser maior que a data de hoje";
        public static string INVALID_EMAIL = "O email do usuário não é válido";
        public static string SCHOOLING_NULL = "Tipo de escolaridade não encontrada. Ela deve ser Infantil, Fundamental, Medio ou Superior";
    }
}