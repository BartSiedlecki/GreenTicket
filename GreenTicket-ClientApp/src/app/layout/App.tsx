import { Button, Carousel, Col, Container, Modal, Row } from "react-bootstrap";
import 'bootstrap/dist/css/bootstrap.min.css';
import { MyVerticallyCenteredModal } from "../../features/Shared/Modal";
import { Route, Routes } from "react-router-dom";
import MainPage from "../../features/Main/MainPage";
import Footer from "./Footer/Footer";
import './../../i18Next'
import { ToastContainer } from "react-toastify";
import 'react-toastify/dist/ReactToastify.min.css'
import EventPage from "../../features/EventPage/EventPage";
import CategoryPage from "../../features/CategoryPage/CategoryPage";
import PartnershipPage from "../../features/InfoPages/PartnershipPage";
import TermsAndConditionsPage from "../../features/InfoPages/TermsAndConditionsPage";
import PrivacyPolicyPage from "../../features/InfoPages/PrivacyPolicyPage";
import LegalNoticePage from "../../features/InfoPages/LegalNoticePage";
import RegisterPage from "../../features/RegisterPage/RegisterPage";
import MainNavBar from "./NavBar/MainNavBar";
import OrderHistoryPage from "../../features/OrderHistory/OrderHistoryPage";
import BasketPage from "../../features/BasketPage/BasketPage";
import PaymentPage from "../../features/PaymentPage/PaymentPage";
import OrderDetailsPage from "../../features/OrderHistory/OrderDetailsPage";


function App() {

    return (
        <div className="main">
            <Container className="main-container rounded shadow-lg px-0">
            <ToastContainer pauseOnHover position="bottom-right" />
                <Row className="w-100 mx-0">
                    <Col className="px-0">
                        <MainNavBar />
                    </Col>
                </Row>
                <Row style={{ minHeight: "70vh" }}>
                    <Col>
                        <Container fluid className="px-0">
                        <Routes>
                                <Route path='*' element={<MainPage />} />
                                <Route path='/main' element={<MainPage />} />
                                <Route path='/event/:eventName/:eventVenue/:eventId' element={<EventPage />} />
                                <Route path='/event/category/:categoryName/:subCategoryName/city/:cityName/:categoryId/:subCategoryId/:cityId/' element={<CategoryPage />} />
                                <Route path='/partnership' element={<PartnershipPage />} />
                                <Route path='/terms-and-conditions' element={<TermsAndConditionsPage />} />
                                <Route path='/privacy-policy' element={<PrivacyPolicyPage />} />
                                <Route path='/legal-notice' element={<LegalNoticePage />} />
                                <Route path='/register' element={<RegisterPage />} />
                                <Route path='/orders' element={<OrderHistoryPage />} />
                                <Route path='/orders/:orderId' element={<OrderDetailsPage />} />
                                <Route path='/payment/:orderId' element={<PaymentPage />} />
                                <Route path='/basket' element={<BasketPage />} />
                        </Routes>
                        </Container>
                    </Col>
                </Row>
                <Row className="w-100 mx-0 mb-5 rounded">
                    <Col className="px-0 rounded">
                        <Footer />
                    </Col>
                </Row>
            </Container>
        </div>
    );
}

export default App;
