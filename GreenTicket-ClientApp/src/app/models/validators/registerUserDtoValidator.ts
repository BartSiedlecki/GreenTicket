import { Validator } from "fluentvalidation-ts";
import i18next from "i18next";
import { RegisterUserDto } from "../registerUserDto";
import { passwordRegex } from "./passwordRegex";

export class RegisterUserDtoValidator extends Validator<RegisterUserDto> {
    constructor() {
        super();

        const loginEmailMaxLength = 50;
        const passwordMaxLength = 50;

        const firstNameMinLength = 2;
        const firstNameMaxLength = 30;

        const lastNameMinLength = 2;
        const lastNameMaxLength = 50;

        const streetMaxLength = 50;
        const streetNoMaxLength = 10;
        const postalCodeMaxLength = 10;
        const cityMaxLength = 10;

        this.ruleFor('email')
            .notEmpty()
            .withMessage(i18next.t("FieldRequired").replace("#fieldName#", i18next.t("Login")))
            .emailAddress()
            .withMessage(i18next.t("EmailFormatInvalid"))
            .maxLength(loginEmailMaxLength)
            .withMessage(i18next.t("FieldMaxLength")
                .replace("#fieldName#", i18next.t("Login"))
                .replace("#length#", loginEmailMaxLength.toString()));

        this.ruleFor('password')
            .notEmpty()
            .withMessage(i18next.t("FieldRequired").replace("#fieldName#", i18next.t("Password")))
            .minLength(8)
            .withMessage(i18next.t("PasswordInvalid"))
            .matches(passwordRegex)
            .withMessage(i18next.t("PasswordInvalid"))
            .maxLength(passwordMaxLength)
            .withMessage(i18next.t("FieldMaxLength")
                .replace("#fieldName#", i18next.t("Password"))
                .replace("#length#", passwordMaxLength.toString()));

        this.ruleFor('repeatPassword')
            .notEmpty()
            .withMessage(i18next.t("FieldRequired").replace("#fieldName#", i18next.t("RepeatPassword")))
            .minLength(8)
            .withMessage(i18next.t("PasswordInvalid"))
            .matches(passwordRegex)
            .withMessage(i18next.t("PasswordInvalid"))
            .must((value, obj) => value === obj.password)
            .withMessage(i18next.t("PasswordsMustBeSame"))
            .maxLength(passwordMaxLength)
            .withMessage(i18next.t("FieldMaxLength")
                .replace("#fieldName#", i18next.t("RepeatPassword"))
                .replace("#length#", passwordMaxLength.toString()));

        this.ruleFor('firstName')
            .notEmpty()
            .withMessage(i18next.t("FieldRequired").replace("#fieldName#", i18next.t("FirstName")))
            .minLength(firstNameMinLength)
            .withMessage(i18next.t("FieldMinLength")
                .replace("#fieldName#", i18next.t("FirstName"))
                .replace("#length#", firstNameMinLength.toString()))
            .maxLength(firstNameMaxLength)
            .withMessage(i18next.t("FieldMaxLength")
                .replace("#fieldName#", i18next.t("FirstName"))
                .replace("#length#", firstNameMaxLength.toString()))

        this.ruleFor('lastName')
            .notEmpty()
            .withMessage(i18next.t("FieldRequired").replace("#fieldName#", i18next.t("LastName")))
            .minLength(lastNameMinLength)
            .withMessage(i18next.t("FieldMinLength")
                .replace("#fieldName#", i18next.t("LastName"))
                .replace("#length#", lastNameMinLength.toString()))
            .maxLength(lastNameMaxLength)
            .withMessage(i18next.t("FieldMaxLength")
                .replace("#fieldName#", i18next.t("LastName"))
                .replace("#length#", lastNameMaxLength.toString()))

        this.ruleFor('dateOfBirth')
            .notNull()
            .withMessage(i18next.t("FieldRequired").replace("#fieldName#", i18next.t("DateOfBirth")))

        this.ruleFor('street')
            .notEmpty()
            .withMessage(i18next.t("FieldRequired").replace("#fieldName#", i18next.t("Street")))
            .maxLength(streetMaxLength)
            .withMessage(i18next.t("FieldMaxLength")
                .replace("#fieldName#", i18next.t("Street"))
                .replace("#length#", streetMaxLength.toString()))

        this.ruleFor('streetNo')
            .notEmpty()
            .withMessage(i18next.t("FieldRequired").replace("#fieldName#", i18next.t("StreetNo")))
            .maxLength(streetNoMaxLength)
            .withMessage(i18next.t("FieldMaxLength")
                .replace("#fieldName#", i18next.t("StreetNo"))
                .replace("#length#", streetNoMaxLength.toString()))

        this.ruleFor('postalCode')
            .notEmpty()
            .withMessage(i18next.t("FieldRequired").replace("#fieldName#", i18next.t("PostalCode")))
            .maxLength(postalCodeMaxLength)
            .withMessage(i18next.t("FieldMaxLength")
                .replace("#fieldName#", i18next.t("PostalCode"))
                .replace("#length#", postalCodeMaxLength.toString()))

        this.ruleFor('city')
            .notEmpty()
            .withMessage(i18next.t("FieldRequired").replace("#fieldName#", i18next.t("City")))
            .maxLength(cityMaxLength)
            .withMessage(i18next.t("FieldMaxLength")
                .replace("#fieldName#", i18next.t("City"))
                .replace("#length#", cityMaxLength.toString()))

        this.ruleFor('countryId')
            .notEmpty()
            .withMessage(i18next.t("FieldRequired").replace("#fieldName#", i18next.t("Country")));
    }
}