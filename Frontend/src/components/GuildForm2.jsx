import React, { useState, useEffect } from 'react';

const GuildForm = () => {
  const [guildName, setGuildName] = useState('');
  const [guildRealm, setGuildRealm] = useState('');

  const handleSubmit = async (e) => {
    e.preventDefault();

    try {
      const response = await fetch('https://localhost:7211/api/Guild', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify({ id: 0, gname: guildName, realm: guildRealm }),
      });

      if (!response.ok) {
        throw new Error('Failed to create guild');
      }

      // Clear the input field after successful creation
      setGuildName('');
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