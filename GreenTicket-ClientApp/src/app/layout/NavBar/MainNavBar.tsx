import { useEffect, useState } from 'react';
import { Col, Nav, Navbar, NavDropdown, Row } from 'react-bootstrap';
import "react-bootstrap-submenu/dist/index.css";
import logo60 from '../../../data/logo/logo60.png';
import agent from '../../API/agent';
import { EventCategoryNavDto } from '../../models/eventCategoryNavDto';
import { SearchInput } from './SearchInput';
import LoginDropDown from './LoginDropDown';
import { LangDropDown } from './LangDropDown';
import { useTranslation } from 'react-i18next';
import { NavLink } from 'react-router-dom';
import { CityDto } from '../../models/cityDto';
import { prepareRoutingParamText } from '../../../features/Shared/helpers';
import { useStore } from '../../store/store';
import LoggedUserDropdown from './LoggedUserDropdown';
import { observer } from 'mobx-react-lite';
import BasketDropdown from './BasketDropdown';

export default observer(function MainNavBar() {
    const { t } = useTranslation();
    const { userStore } = useStore();
    const logoImg = logo60;
    const [navCategories, setNavCategories] = useState<EventCategoryNavDto[]>([]);
    const [navCities, setNavCities] = useState<CityDto[]>([]);


    useEffect(() => {
        agent.Categories.getNavigation()
            .then(response => setNavCategories(response));

        agent.Addresses.getNavigation()
            .then(response => setNavCities(response));
    }, []);

    return (
        <Navbar sticky="top" className="main-nav-bar rounded-top " expand="lg" >
            <Row className="w-100 mx-0">
                <Col xs={6} lg={2} className="pt-1">
                    <Navbar.Brand as={NavLink} to={`/main`} className="ps-2">
                        <img src={logoImg} alt="logo green ticket" width={30} height={30} />
                        <strong className="ms-2 green-logo-color">Green Ticket</strong>
                    </Navbar.Brand>
                </Col>
                <Col xs={6} className="d-lg-none text-end">
                    <Navbar.Toggle aria-controls="basic-navbar-nav" />
                </Col>
                <Col xs={12} lg={3} xxl={2} className="px-2 px-lg-4">
                    <Navbar.Collapse id="basic-navbar-nav">
                        <Nav className="me-auto">
                            <NavDropdown title={t("Categories")} id="nav-categories" className="nav-category">
                                {navCategories.map((category, catIndex) =>
                                    <NavDropdown key={catIndex} title={t(category.title)} id={`nav-category-${category.title}`} className="nav-subcategory">
                                        {category.subCategories.map((subCategory, subCatIndex) =>
                                            <NavDropdown.Item
                                                key={subCatIndex}
                                                as={NavLink}
                                                to={`/event/category/${prepareRoutingParamText(category.title)}/${prepareRoutingParamText(subCategory.title)}/city/all/${category.id}/${subCategory.id}/0/`}>{`${t(subCategory.title)} (${subCategory.noOfEventsOnSale})`}</NavDropdown.Item>
                                        )}
                                    </NavDropdown>
                                )}
                            </NavDropdown>
                            <NavDropdown title={t("Cities")} id="nav-cities" className="nav-category">
                                {navCities.map((city, index) =>
                                    <NavDropdown.Item key={index} as={NavLink} to={`/event/category/all/all/city/${prepareRoutingParamText(city.name)}/0/0/${city.id}/`}>{`${city.name}`}</NavDropdown.Item>
                                )}
                            </NavDropdown>
                        </Nav>
                    </Navbar.Collapse>
                </Col>
                <Col xs={12} lg={5} className="pt-3 pb-1 pt-lg-0 pb-lg-0">
                    <SearchInput />
                </Col>
                <Col xs={6} lg={2} xxl={3} className="d-none d-lg-flex">
                    <div className="p-2 w-100"></div>
                    <BasketDropdown className="ms-0 my-3 ms-lg-3 my-lg-0 pt-2 dropstart dropdown" />
                    <LangDropDown className="ms-0 my-3 ms-lg-3 my-lg-0 pt-2 dropstart" />
                    {userStore.user ?
                        <LoggedUserDropdown className="ms-0 my-3 ms-lg-3 my-lg-0 pt-2 dropstart" />
                        :
                        <LoginDropDown className="ms-0 my-3 ms-lg-3 my-lg-0 pt-2 dropstart" />
                    }
                </Col>
            </Row>
        </Navbar>
    )
})