import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import { RoutesNames } from '../constants';

const GuildTable = () => {
  const [dataArray, setDataArray] = useState([]);
  const navigate = useNavigate();

  useEffect(() => {
    // Fetch or import your data here
    fetch(
        "https://localhost:7211/api/Guild")
        .then(response => {return response.json()})
        .then((data) => {console.log(data);setDataArray(data);})},  []);

        const handleGuildClick = (guildId) => {
          navigate(`${RoutesNames.MEMBERS.replace(':guildId', guildId)}`);
        };

  return (
    <>
    <div>
      <h2>Guild list</h2>
      <table>
        <thead>
          <tr>
            <th>ID</th>
            <th>Name</th>
            <th>Realm</th>
          </tr>
        </thead>
        <tbody>
          {dataArray.map((item) => (
            <tr key={item.id} onClick={() => handleGuildClick(item.id)}>
              <td>{item.id}</td>
              <td>{item.gname}</td>
              <td>{item.realm}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
    </>
  );
};


export default GuildTable;