import './App.css';
import LoginPage from './Pages/LoginPage';
import RegisterPage from './Pages/RegisterPage';
import { Routes, Route } from "react-router-dom";
import { BrowserRouter as Router } from "react-router-dom";
import Overview from './Components/Overview';
import CategoryButton from './Components/CategoryButton';
import CategoriesContainer from './Components/CategoriesContainer';
import HomePage from './Pages/HomePage';
import AddRecordButton from './Components/AddRecordButton';

function App() {
  return (
    <div>
      {/* <Router>
        <Routes>
          <Route exact path='/' element={< LoginPage />}></Route>
          <Route exact path='/register' element={< RegisterPage />}></Route>
        </Routes>
      </Router> */}
      {/* <Overview
        duration={1.6}
        numberOfSessions={6}
        numberOfCalories={460}></Overview> */}
      <HomePage />
      {/* <AddRecordButton /> */}
    </div>
  );
}

export default App;
