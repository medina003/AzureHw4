import React, { useState, useEffect } from "react";
import { useParams } from "react-router-dom";

function CarDetails() {
  const { id } = useParams();
  const [url, setUrl] = useState("https://localhost:7280/Car/Cars");
  const [cars, setCars] = useState([]);
  const [car, setCar] = useState(null);

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
  }, []);

  useEffect(() => {
    if (cars.length > 0) {
      const foundCar = cars.find((car) => car.id === parseInt(id));
      setCar(foundCar);
      console.log(car);
    }
  }, [cars, id]);
  return (
    <div className="car-details">
      {car && (
        <>
          <img src={car.image} alt="car" width={500} height={500} />
          <h2>{car.name}</h2>
          <p>Description: {car.description}</p>
          <p>Model: {car.model}</p>
          <p>Price: {car.price}</p>
          <p>Speed: {car.speed}</p>
          <p>Color: {car.color}</p>
        </>
      )}
    </div>
  );
}

export default CarDetails;
