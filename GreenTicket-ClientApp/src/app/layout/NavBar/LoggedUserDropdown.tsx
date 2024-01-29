import { Col, Container, NavDropdown, Row } from "react-bootstrap";
import { BoxArrowRight, Person } from "react-bootstrap-icons";
import { useTranslation } from "react-i18next";
import { NavLink } from "react-router-dom";
import { useStore } from "../../store/store";

interface Props {
    className: string
}

export default function LoggedUserDropdown({ className } : Props) {
    const { t } = useTranslation();
    const { userStore } = useStore();

    const welcomeMessage = userStore.user ? <span>{t("Welcome")}, {userStore.user.firstName}</span> : undefined;

    return (
        <>
            <NavDropdown
                id="user-nav-dropdown"
                autoClose="outside"
                className={className}
                title={<span>
                    <Person
                        height={26}
                        width={26}
                    />
                    {welcomeMessage}
                </span>
                }
            >
                <Container className="dropdown-menu-lg-start px-0" style={{ minWidth: "330px" }}>
                    <NavDropdown.Item
                        as={NavLink}
                        to={`/orders`} >{t("MyOrders")}</NavDropdown.Item>
                    <NavDropdown.Item href="#action/3.1">{t("PersonalData")}</NavDropdown.Item>
                    <NavDropdown.Divider />
                    <NavDropdown.Item onClick={() => userStore.logout()} ><BoxArrowRight /> Log out</NavDropdown.Item>
                </Container>
            </NavDropdown>
        </>
    )
}