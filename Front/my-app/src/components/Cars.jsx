import React from "react";
import { useState, useEffect } from "react";
import "../App.css";
import { Link } from "react-router-dom";

const Cars = () => {
  const [url, setUrl] = useState("https://localhost:7280/Car/Cars");
  const [cars, setCars] = useState([]);

  const fetchCars = async () => {
    try {
      const response = await fetch(url);
      const data = await response.json();
      setCars(data);
      console.log(data);
    } catch (error) {
      console.error(error);
    }
  };
  useEffect(() => {
    fetchCars();
    console.log("se");
  }, []);
  return (
    <div className="cards">
      {cars.map((car) => (
        <Link to={`/cars/${car.id}`}>
          <div className="card-container">
            <div className="image">
              <img width={400} height={300} src={car.image}></img>
            </div>
            <div className="about">
              <span>{car.price} AZN</span>
              <span>
                {car.name} {car.model}
              </span>
            </div>
          </div>
        </Link>
      ))}
    </div>
  );
};

export default Cars;
