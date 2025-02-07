using System;
namespace Itmo.ObjectOrientedProgramming.Lab2;
public class ComputerBuilder : IComputerBuilder
    {
        private ComputerCase? _computerCase;
        private Cooler? _cooler;
        private Cpu? _cpu;
        private MotherBoard? _motherBoard;
        private PowerUnit? _powerUnit;
        private Ram? _ram;
        private Bios? _bios;
        private WiFiAdapter? _wifiAdapter;
        private XmpProfile? _xmpProfile;
        private Hsd? _hsd;
        private Ssd? _ssd;
        private VideoCard? _videoCard;
        public ComputerBuilder AddComputerCase(ComputerCase computerCase)
        {
            _computerCase = computerCase;
            return this;
        }

        public ComputerBuilder AddCooler(Cooler cooler)
        {
            _cooler = cooler;
            return this;
        }

        public ComputerBuilder AddCpu(Cpu cpu)
        {
            _cpu = cpu;
            return this;
        }

        public ComputerBuilder AddMotherBoard(MotherBoard motherBoard)
        {
            _motherBoard = motherBoard;
            return this;
        }

        public ComputerBuilder AddPowerUnit(PowerUnit powerUnit)
        {
            _powerUnit = powerUnit;
            return this;
        }

        public ComputerBuilder AddRam(Ram ram)
        {
            _ram = ram;
            if (_motherBoard?.NumberOfDDRSlots > 0)
            {
                _motherBoard.DecreaserOfDdrSlots();
            }
            else
            {
                throw new InvalidOperationException("You have exhausted the number of slots");
            }

            return this;
        }

        public ComputerBuilder AddBios(Bios bios)
        {
            _bios = bios;
            return this;
        }

        public ComputerBuilder AddWifiAdapter(WiFiAdapter wiFi)
        {
            _wifiAdapter = wiFi;
            return this;
        }

        public ComputerBuilder AddXmpProfile(XmpProfile xmpProfile)
        {
            _xmpProfile = xmpProfile;
            return this;
        }

        public ComputerBuilder AddHsd(Hsd hsd)
        {
            _hsd = hsd;
            return this;
        }

        public ComputerBuilder AddSsd(Ssd ssd)
        {
            _ssd = ssd;
            return this;
        }

        public ComputerBuilder AddVideocard(VideoCard videocard)
        {
            _videoCard = videocard;
            return this;
        }

        public ComputerBuilder AddAllComponents(ComputerCase computerCase, Cooler cooler, Cpu cpu, MotherBoard motherBoard, PowerUnit powerUnit, Ram ram, Bios bios, WiFiAdapter wiFi, XmpProfile xmpProfile, Hsd hsd, Ssd ssd, VideoCard videocard)
        {
            AddComputerCase(computerCase);
            AddCooler(cooler);
            AddCpu(cpu);
            AddMotherBoard(motherBoard);
            AddPowerUnit(powerUnit);
            AddRam(ram);
            AddBios(bios);
            AddWifiAdapter(wiFi);
            AddXmpProfile(xmpProfile);
            AddHsd(hsd);
            AddSsd(ssd);
            AddVideocard(videocard);
            return this;
        }

        public Computer Build()
        {
            if (_computerCase == null) throw new ArgumentNullException(nameof(ComputerCase));
            if (_cooler == null) throw new ArgumentNullException(nameof(Cooler));
            if (_cpu == null) throw new ArgumentNullException(nameof(Cpu));
            if (_motherBoard == null) throw new ArgumentNullException(nameof(MotherBoard));
            if (_powerUnit == null) throw new ArgumentNullException(nameof(PowerUnit));
            if (_ram == null) throw new ArgumentNullException(nameof(Ram));
            if (_bios == null) throw new ArgumentNullException(nameof(Bios));
            if (_wifiAdapter == null) throw new ArgumentNullException(nameof(WiFiAdapter));
            if (_xmpProfile == null) throw new ArgumentNullException(nameof(XmpProfile));
            if (_ssd == null) throw new ArgumentNullException(nameof(Hsd));
            if (_hsd == null) throw new ArgumentNullException(nameof(Ssd));
            if (_videoCard == null) throw new ArgumentNullException(nameof(VideoCard));
            return new Computer(_computerCase, _cooler, _cpu, _motherBoard, _powerUnit, _ram, _bios, _wifiAdapter, _xmpProfile, _hsd, _ssd, _videoCard);
        }
    }