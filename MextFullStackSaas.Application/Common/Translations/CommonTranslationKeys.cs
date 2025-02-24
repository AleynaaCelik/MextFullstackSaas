﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullStackSaas.Application.Common.Translations
{
    public static class CommonTranslationKeys
    {
        //GeneralException meajlarını yönetilebilir yapmak için

        //GeneralKeys
        public static string GeneralValidationExceptionMessage => nameof(GeneralValidationExceptionMessage);
        public static string GeneralServerExceptionMessage => nameof(GeneralServerExceptionMessage);
        //UsrAuth Keys
        public static string UserAuthRegisterSuccededMessage=>nameof(UserAuthRegisterSuccededMessage);
        public static string UserAuthVerifyEmailSuccededMessage=>nameof(UserAuthVerifyEmailSuccededMessage);

        public static string EmailVerificationSubject => nameof(EmailVerificationSubject);
        public static string EmailVerificationButtonText => nameof(EmailVerificationButtonText);
        public static string EmailVerificationContent => nameof(EmailVerificationContent);

        //Forgot Password
        public static  string ForgotPasswordSuccessMessage = nameof(ForgotPasswordSuccessMessage);
        public static string ForgotPasswordFailureMessage = nameof(ForgotPasswordFailureMessage);
        //ResetPassword
        public const string ResetPasswordSuccessMessage = nameof(ResetPasswordSuccessMessage);
        public const string ResetPasswordFailureMessage = nameof(ResetPasswordFailureMessage);
    }
}
