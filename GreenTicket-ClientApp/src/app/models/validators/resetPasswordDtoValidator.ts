import { Validator } from "fluentvalidation-ts";
import i18next from "i18next";
import { ResetPasswordDto } from "../resetPasswordDto";

export class ResetPasswordDtoValidator extends Validator<ResetPasswordDto> {
    constructor() {
        super();

        this.ruleFor('email')
            .notEmpty()
            .withMessage(i18next.t("LoginRequired"))
            .emailAddress()
            .withMessage(i18next.t("EmailFormatInvalid"));
    }
}