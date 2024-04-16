import { useEffect, useState } from "react";
import { Button, Container, Table } from "react-bootstrap";
import { useNavigate } from "react-router-dom";
import GuildTable from "../components/GuildTable";

import React from 'react';

const Guilds = () => {
  return (
    <div>
      <GuildTable/>
    </div>
  );
};

export default Guilds;