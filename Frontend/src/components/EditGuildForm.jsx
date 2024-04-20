import React, { useState } from 'react';

const EditGuildForm = ({ guildId }) => {
  const [formData, setFormData] = useState({
    id: guildId
  });

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData({ ...formData, [name]: value });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    
    try { 
      const response = await fetch(`http://guildboard.runasp.net/api/Guild/${guildId}`, {
        method: 'PUT',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(formData),
      });

      if (!response.ok) {
        throw new Error('Failed to update guild');
      }

      // Optionally, you can handle the success response here
      console.log('Guild updated successfully');

    } catch (error) {
      console.error('Error updating guild:', error.message);
    }
  };

  return (
    <form onSubmit={handleSubmit}>
      <label>
        Guild Name:
        <input
          type="text"
          name="gname"
          value={formData.gname}
          onChange={handleChange}
        />
      </label>
      <label>
        Realm:
        <input
          type="text"
          name="realm"
          value={formData.realm}
          onChange={handleChange}
        />
      </label>
      <button type="submit">Update Guild</button>
    </form>
  );
};

export default EditGuildForm;