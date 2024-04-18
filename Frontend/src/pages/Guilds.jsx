import { useEffect, useState } from "react";
import { Button, Container, Table } from "react-bootstrap";
import { useNavigate } from "react-router-dom";
import CreateGuildForm from "../components/GuildForm2";
import GuildTable from "../components/GuildTable";
import GuildForm from "../components/GuildForm2";

import React from 'react';

const Guilds = () => {
  return (
    <div>
      <GuildTable/>
      <GuildForm/>
    </div>
  );
};

export default Guilds;