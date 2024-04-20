import React from 'react';

const DeleteGuildButton = ({ guildId, onDelete }) => {
  const handleDelete = async () => {
    try {
      const response = await fetch(`http://guildboard.runasp.net/api/Guild/${guildId}`, {
        method: 'DELETE',
      });

      if (!response.ok) {
        throw new Error('Failed to delete guild');
      }

      console.log('Guild deleted successfully');

      onDelete(guildId);
    } catch (error) {
      console.error('Error deleting guild:', error.message);
    }
  };

  return (
    <button onClick={handleDelete}>Delete Guild</button>
  );
};

export default DeleteGuildButton;
