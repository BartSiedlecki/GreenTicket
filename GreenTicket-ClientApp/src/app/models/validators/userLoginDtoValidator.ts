import { Validator } from "fluentvalidation-ts";
import i18next from "i18next";
import { LoginUserDto } from "../loginUserDto";
import { passwordRegex } from "./passwordRegex";

export class UserLoginDtoValidator extends Validator<LoginUserDto>{
    constructor() {
        super();

        this.ruleFor('login')
            .notEmpty()
            .withMessage(i18next.t("LoginRequired"))
            .emailAddress()
            .withMessage(i18next.t("EmailFormatInvalid"));

        this.ruleFor('password')
            .notEmpty()
            .withMessage(i18next.t("PasswordRequired"))
            .minLength(8).matches(passwordRegex)
            .withMessage(i18next.t("PasswordInvalid"));
    }
}

