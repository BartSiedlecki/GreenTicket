import { makeAutoObservable, runInAction } from "mobx"
import { toast } from "react-toastify";
import i18n from "../../i18Next";
import agent from "../API/agent";
import { LoggedUserDto } from "../models/loggedUserDto";
import { LoginUserDto } from "../models/loginUserDto";
import { LogoutUserDto } from "../models/logoutUserDto";

export class UserStore {

    constructor() {
        makeAutoObservable(this)
    }

    user: LoggedUserDto | null = null;

    login = async (creds: LoginUserDto) => {
        try {
            const user = await agent.Accounts.login(creds)
            runInAction(() => this.user = user);
            toast.success(`${i18n.t("LoginSuccess")} ${i18n.t("Welcome")} ${user.firstName}!`);
        } catch (error) {
            throw error;
        }
    }

    logout = () => {
        if (this.user) {
            const logoutUserDto: LogoutUserDto = {
                id: this.user.id
            }

            agent.Accounts.logout(logoutUserDto);
        }

        this.user = null;
        toast.success(`${i18n.t("LogoutSuccess")}`);
    }
}