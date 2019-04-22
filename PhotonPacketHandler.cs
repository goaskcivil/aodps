using System;
using System.IO;
using System.Net;
using ExitGames.Client.Photon;
using PcapDotNet.Packets;
using PcapDotNet.Packets.Transport;

namespace AODPSo
{
	internal class PhotonPacketHandler
	{
		public PhotonPacketHandler(PacketHandler p)
		{
			this._eventHandler = p;
		}

		public void PacketHandler(Packet packet)
		{
			Protocol16 protocol16 = new Protocol16();
			UdpDatagram udp = packet.Ethernet.IpV4.Udp;
			if (udp.SourcePort != 5056 && udp.DestinationPort != 5056)
			{
				return;
			}
			BinaryReader p = new BinaryReader(udp.Payload.ToMemoryStream());
			IPAddress.NetworkToHostOrder((int)p.ReadUInt16());
			p.ReadByte();
			byte commandCount = p.ReadByte();
			IPAddress.NetworkToHostOrder(p.ReadInt32());
			IPAddress.NetworkToHostOrder(p.ReadInt32());
			int commandHeaderLength = 12;
			int signifierByteLength = 1;
			for (int commandIdx = 0; commandIdx < (int)commandCount; commandIdx++)
			{
				try
				{
					byte commandType = p.ReadByte();
					p.ReadByte();
					p.ReadByte();
					p.ReadByte();
					int commandLength = IPAddress.NetworkToHostOrder(p.ReadInt32());
					IPAddress.NetworkToHostOrder(p.ReadInt32());
					switch (commandType)
					{
					case 4:
						goto postPositionUpdate;
					case 5:
						goto prePositionUpdate;
					case 6:
						break;
					case 7:
						p.BaseStream.Position += 4L;
						commandLength -= 4;
						break;
					default:
						goto prePositionUpdate;
					}
					p.BaseStream.Position += (long)signifierByteLength;
					byte messageType = p.ReadByte();
					int operationLength = commandLength - commandHeaderLength - 2;
					StreamBuffer payload = new StreamBuffer(p.ReadBytes(operationLength));
					switch (messageType)
					{
					case 2:
					{
						OperationRequest requestData = protocol16.DeserializeOperationRequest(payload);
						this._eventHandler.OnRequest(requestData.OperationCode, requestData.Parameters);
						goto postPositionUpdate;
					}
					case 3:
					{
						OperationResponse responseData = protocol16.DeserializeOperationResponse(payload);
						this._eventHandler.OnResponse(responseData.OperationCode, responseData.ReturnCode, responseData.Parameters);
						goto postPositionUpdate;
					}
					case 4:
					{
						EventData eventData = protocol16.DeserializeEventData(payload);
						this._eventHandler.OnEvent(eventData.Code, eventData.Parameters);
						goto postPositionUpdate;
					}
					default:
						p.BaseStream.Position += (long)operationLength;
						goto postPositionUpdate;
					}
					prePositionUpdate:
					p.BaseStream.Position += (long)(commandLength - commandHeaderLength);
					postPositionUpdate:;
				}
				catch (Exception)
				{
				}
			}
		}

		private PacketHandler _eventHandler;
	}
}
