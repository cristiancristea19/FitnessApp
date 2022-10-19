import './App.css';
import LoginPage from './Pages/LoginPage';
import RegisterPage from './Pages/RegisterPage';
import { Routes, Route } from "react-router-dom";
import { BrowserRouter as Router } from "react-router-dom";
import HomePage from './Pages/HomePage';
import ProtectedRoute from './Components/ProtectedRoute';
function App() {
  return (
    <div>
      <Router>
        <Routes>
          <Route exact path='/' element={< LoginPage />}></Route>
          <Route exact path='/register' element={< RegisterPage />}></Route>
          <Route path="/home" element={<ProtectedRoute children={<HomePage />} />} />
        </Routes>
      </Router>
    </div>
  );
}

export default App;
