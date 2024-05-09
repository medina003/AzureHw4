import "./App.css";
import Cars from "./components/Cars";
import CarDetails from "./components/CarDetails";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
function App() {
  return (
    <div className="App">
      <Router>
        <div>
          <Routes>
            <Route path="/" element={<Cars />} />
            <Route path="/cars/:id" element={<CarDetails />} />
          </Routes>
        </div>
      </Router>
    </div>
  );
}

export default App;
