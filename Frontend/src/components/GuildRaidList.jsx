import React, { useState, useEffect } from 'react';

const GuildRaidList = ({ guildId }) => {
  const [raidInfo, setRaidInfo] = useState([]);

  useEffect(() => {
    fetch(`https://localhost:7211/api/raidInfo/${guildId}`)
      .then(response => response.json())
      .then(data => {
        console.log('Data from API:', data); // Log the data fetched from the API
        setRaidInfo(data); // Set members state
      })
      .catch(error => console.error('Error fetching data:', error)); // Log any errors
  }, [guildId]);


  return (
    <div>
      <h2>Raid progress</h2>
      <ul>
        {raidInfo.map(raid => (
          <li>{raid.raidName}, {raid.clearDate}, {raid.difficulty}</li>
        ))}
      </ul>
    </div>
  );
};

export default GuildRaidList;