import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import { RoutesNames } from '../constants';
import DeleteGuildButton from './DeleteGuildButton'; // Import the DeleteGuildButton component

const GuildTable = () => {
  const [dataArray, setDataArray] = useState([]);
  const navigate = useNavigate();

  useEffect(() => {
    // Fetch or import your data here
    fetch("https://localhost:7211/api/Guild")
      .then(response => response.json())
      .then(data => setDataArray(data));
  }, []);

  const handleGuildClick = (guildId) => {
    navigate(`${RoutesNames.MEMBERS.replace(':guildId', guildId)}`);
  };

  const handleDeleteGuild = (guildId) => {
    // Filter out the deleted guild from the dataArray
    const updatedDataArray = dataArray.filter(item => item.id !== guildId);
    setDataArray(updatedDataArray);
  };

  return (
    <div>
      <h2>Guild list</h2>
      <table>
        <thead>
          <tr>
            <th>ID</th>
            <th>Name</th>
            <th>Realm</th>
            <th>Actions</th> {/* Add a new table header for actions */}
          </tr>
        </thead>
        <tbody>
          {dataArray.map((item) => (
            <tr key={item.id}>
              <td onClick={() => handleGuildClick(item.id)}>{item.id} </td>
              <td>{item.gname}</td>
              <td>{item.realm}</td>
              <td>
                <DeleteGuildButton
                  guildId={item.id}
                  onDelete={() => handleDeleteGuild(item.id)}
                />
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default GuildTable;