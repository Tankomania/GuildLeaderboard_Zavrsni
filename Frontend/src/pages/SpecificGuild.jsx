import React from 'react';
import GuildRaidList from '../components/GuildRaidList';
import MemberList from '../components/MemberList';
import { useParams } from 'react-router-dom';

const SpecificGuild = () => {
    const { guildId } = useParams();

    console.log('Guild ID in useparams:', guildId);

  return (
    <>
    <div style={{ display: 'flex', justifyContent: 'center' }}>
      <MemberList guildId={guildId} />
    </div>
    <div style={{ display: 'flex', justifyContent: 'center' }}>
      <GuildRaidList guildId={guildId}></GuildRaidList>
    </div>
    </>
  );
};

export default SpecificGuild;