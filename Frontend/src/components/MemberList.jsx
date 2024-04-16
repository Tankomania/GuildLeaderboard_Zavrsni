import React, { useState, useEffect } from 'react';

const MemberList = ({ guildId }) => {
  const [members, setMembers] = useState([]);

  useEffect(() => {
    fetch(`https://localhost:7211/api/guildmembers/${guildId}`)
      .then(response => response.json())
      .then(data => {
        console.log('Data from API:', data); // Log the data fetched from the API
        setMembers(data); // Set members state
      })
      .catch(error => console.error('Error fetching data:', error)); // Log any errors
  }, [guildId]);

  console.log("Guild ID:" + guildId);
  console.log('Members:', members); // Log the members state

  return (
    <div>
      <h2>Member List</h2>
      <table>
        <thead>
          <th>Nickname</th>
          <th>Class</th>
          <th>Race</th>
        </thead>
        {members.map(member => (
          <tr>
          <td>{member.memname}</td>
          <td>{member.memclass}</td>
          <td>{member.race}</td>
          </tr>
        ))}
      </table>
    </div>
  );
};

export default MemberList;