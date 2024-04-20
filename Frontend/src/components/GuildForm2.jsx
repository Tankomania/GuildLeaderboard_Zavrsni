import React, { useState, useEffect } from 'react';

const GuildForm = () => {
  const [guildName, setGuildName] = useState('');
  const [guildRealm, setGuildRealm] = useState('');

  const handleSubmit = async (e) => {
    e.preventDefault();

    try {
      const response = await fetch('http://guildboard.runasp.net/api/Guild', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify({ id: 0, gname: guildName, realm: guildRealm }),
      });

      if (!response.ok) {
        throw new Error('Failed to create guild');
      }

      setGuildName('');
      setGuildRealm('');
    } catch (error) {
      console.error('Error creating guild:', error.message);
    }
  };

  return (
    <form onSubmit={handleSubmit}>
      <label>
        Guild Name:
        <input
          type="text"
          value={guildName}
          onChange={(e) => setGuildName(e.target.value)}
        />
        Guild Realm:
        <input 
            type="text"
            value={guildRealm}
            onChange={(f) => setGuildRealm(f.target.value)}
        />
      </label>
      <button type="submit">Create Guild</button>
    </form>
  );
};

export default GuildForm;
