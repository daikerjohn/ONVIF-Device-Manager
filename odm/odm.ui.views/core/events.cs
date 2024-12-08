using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml;
using Prism.Events;
using odm.core;
using odm.ui.controls;
using odm.ui.core;
using odm.ui.viewModels;
using onvif.services;
using onvif.utils;

namespace odm.ui.views {

    public class MetaDataConfigEvent : PubSubEvent<string> { }

    public class UpgradeEventArgs {
        public OdmSession facade;
        public string path;
    }
    public class UpgradeStartedEvent : PubSubEvent<UpgradeEventArgs> { }

    public class DeviceSelectedEventArgs { 
        public DeviceDescriptionHolder devHolder;
        public NvtSessionFactory sessionFactory;
    }
    public class DeviceSelectedEvent : PubSubEvent<DeviceSelectedEventArgs> { }

    public class RefreshSelection : PubSubEvent<object> { }
	public class ChannelLoadedEventArgs { 
		public INvtSession session;
		public String token;
	}
	public class ChannelLoadedEvent : PubSubEvent<ChannelLoadedEventArgs> { }

    public class DeviceEventsEventArgs : DeviceLinkEventArgs {
        public EventsStorage events;
		public ObservableCollection<FilterExpression> filters;
    }
	public class MaintenanceLinkEventArgs : DeviceLinkEventArgs, IMaintenanceLinkEventArgs {
        public global::onvif.services.Capabilities caps;

		public string DeviceModel { get; set; }
		public string Manufacturer {get; set; }
	}
	public interface IMaintenanceLinkEventArgs {
		string DeviceModel { get; }
		string Manufacturer { get; }
	}
	public class UserManagementEventArgs : DeviceLinkEventArgs, IUserManagementEventArgs {
		public string DeviceModel { get; set; }
		public string Manufacturer { get; set; }
	}
	public interface IUserManagementEventArgs {
		string DeviceModel { get; }
		string Manufacturer { get; }
	}

	public class DeviceLinkEventArgs {
        public INvtSession session;
        public Account currentAccount;
    }
    public class BatchTaskEventArgs {
        public INvtSession session;
        public Account currentAccount;
        public List<DeviceDescriptionHolder> Devices;
    }
	public class SysLogLinkEventArgs {
		public INvtSession session;
		public Account currentAccount;
		public SysLogDescriptor sysLog;
	}

	public class SysLogType {
		public SysLogType(global::onvif.services.SystemLogType type) {
			this.type = type;
			Name = typeNames.ContainsKey(type) ? typeNames[type] : "";
		}
		Dictionary<global::onvif.services.SystemLogType, string> typeNames = new Dictionary<SystemLogType, string>() { 
			{ global::onvif.services.SystemLogType.access, "Access" }, 
			{ global::onvif.services.SystemLogType.system, "System" } 
		};
		public SystemLogType type;
		public string Name { get; set; }
	}
	public class SysLogDescriptor {
		public SysLogDescriptor(SysLogType logType, AttachmentData att, string log, bool isReceived = false) {
			this.LogType = LogType;
			this.Attachment = att;
			this.SystemLog = log;
			IsReceived = isReceived;
		}
		public bool IsReceived { get; private set; }

		public void FillData(global::onvif.services.SystemLog log, SysLogType slogType) {
			arriveTime = System.DateTime.Now;
			LogType = slogType;
			Attachment = log.binary;
			SystemLog = log.@string;

			IsReceived = true;
		}

		System.DateTime arriveTime;
		
		public string AttachmentFileName {
			get {
				return String.Format("{0:yyyy.MM.dd-hh.mm}-{1}.bin", arriveTime, LogType.Name);
			}
		}
		public string SysLogFileName {
			get {
				return String.Format("{0:yyyy.MM.dd-hh.mm}-{1}.txt", arriveTime, LogType.Name);
			}
		}
		
		public string Info {
			get {
				return String.Format("{1} log at {0:t} on {0:d}", arriveTime, LogType.Name);
			}
		}

		private SysLogType logType;
		public SysLogType LogType {
			get { return logType; }
			private set {logType = value; }
		}

		private AttachmentData attachment;
		public AttachmentData Attachment {
			get { return attachment; }
			private set {attachment = value; }
		}

		private string systemLog;
		public string SystemLog {
			get { return systemLog; }
			private set {systemLog = value; }
		}

	}
	public class SystemLogReceived : PubSubEvent<SysLogDescriptor> { }

	#region commonDevice
	public class WebPageClick : PubSubEvent<DeviceLinkEventArgs> { }
    public class IdentificationClick : PubSubEvent<DeviceLinkEventArgs> { }
	public class ReceiversClick : PubSubEvent<DeviceLinkEventArgs> { }
    public class DateTimeClick : PubSubEvent<DeviceLinkEventArgs> { }
    public class MaintenanceClick : PubSubEvent<MaintenanceLinkEventArgs> { }
    public class SystemLogClick : PubSubEvent<SysLogLinkEventArgs> { }
    public class DigitalIOClick : PubSubEvent<DeviceLinkEventArgs> { }
    public class ActionsClick : PubSubEvent<DeviceLinkEventArgs> { }
    public class ActionTriggersClick : PubSubEvent<DeviceLinkEventArgs> { }
    public class DeviceEventsClick : PubSubEvent<DeviceEventsEventArgs> { }
	public class AddEventsFilterClick : PubSubEvent<DeviceEventsEventArgs> { }
    public class NetworkClick : PubSubEvent<DeviceLinkEventArgs> { }
    public class XMLExplorerClick : PubSubEvent<DeviceLinkEventArgs> { }
	public class UserManagerClick : PubSubEvent<UserManagementEventArgs> { }
    public class SecurityClick : PubSubEvent<DeviceLinkEventArgs> { }
    public class AccountManagerClick : PubSubEvent<DeviceLinkEventArgs> { }
    public class AppSettingsClick : PubSubEvent<bool> { }
    public class UpgradeButchClick : PubSubEvent<bool> { }
    public class UpgradeButchReady : PubSubEvent<BatchTaskEventArgs> { }
    public class RestoreButchClick : PubSubEvent<bool> { }
    public class RestoreButchReady : PubSubEvent<BatchTaskEventArgs> { }
    public class BackgroundTasksClick : PubSubEvent<bool> { }
    public class AboutClick : PubSubEvent<DeviceLinkEventArgs> { }
    public class Refresh : PubSubEvent<bool> { }
	public class ReleaseUI : PubSubEvent<bool> { }
	#endregion commonDevice

	public class InitAccountEventArgs {
		public Account currentAccount;
		public bool needrefresh;
	}
	public class InitAccounts : PubSubEvent<InitAccountEventArgs> { }

    public class MetadataEventArgs {
        public Profile profile;
        public INvtSession session;
        public String token;
        public string profileToken;
        public Account currentAccount;
        public IVideoInfo videoInfo;
    }
    public class ChannelLinkEventArgs {
        public INvtSession session;
        public String token;
        public Profile profile;
		public Account currentAccount;
        public IVideoInfo videoInfo;
    }
	public class UITestEventArgs {
		public Profile profile;
		public INvtSession session;
		public String token;
		public string profileToken;
		public Account currentAccount;
		public IVideoInfo videoInfo;
	}
	public class UITestClick : PubSubEvent<UITestEventArgs> { }

	#region Channels
	public class ProfilesClick : PubSubEvent<ChannelLinkEventArgs> { }
    public class PTZClick : PubSubEvent<ChannelLinkEventArgs> { }
    public class AnalyticsClick : PubSubEvent<ChannelLinkEventArgs> { }
    public class RulesClick : PubSubEvent<ChannelLinkEventArgs> { }
    public class LiveVideoClick : PubSubEvent<ChannelLinkEventArgs> { }
    public class VideoStreamingClick : PubSubEvent<ChannelLinkEventArgs> { }
    public class MetadataClick : PubSubEvent<MetadataEventArgs> { }
    public class EventsClick : PubSubEvent<ChannelLinkEventArgs> { }
    public class ImagingClick : PubSubEvent<ChannelLinkEventArgs> { }

    public class VideoChangedEvent : PubSubEvent<ChannelLinkEventArgs> { }
	#endregion Channels

	#region NVAEvents
	public class NVALinkEventArgs {
		public INvtSession session;
		public AnalyticsEngine engine;
		public AnalyticsEngineControl control;
		public Account currentAccount;
		public IVideoInfo videoInfo;
	}
	public class ControlChangedEventArgs {
		public ControlChangedEventArgs(INvtSession session, AnalyticsEngine engine, string controlToken) {
			this.session = session;
			this.engine = engine;
			this.controlToken = controlToken;
		}
		public INvtSession session;
		public string controlToken;
		public AnalyticsEngine engine;
	}
	public class ControlChangedPreviewEvent : PubSubEvent<ControlChangedEventArgs> { }
	public class ControlChangedEvent : PubSubEvent<ControlChangedEventArgs> { }

	public class NVALiveVideoClick : PubSubEvent<NVALinkEventArgs> { }
	public class NVAControlsClick : PubSubEvent<NVALinkEventArgs> { }
	public class NVAAnalyticsClick : PubSubEvent<NVALinkEventArgs> { }
	public class NVAInputsClick : PubSubEvent<NVALinkEventArgs> { }
    public class NVAMetadataClick : PubSubEvent<NVALinkEventArgs> { }
	public class NVASettingsClick : PubSubEvent<NVALinkEventArgs> { }

	#endregion NVAEvents

	public class ProfileChangedEventArgs{
        public ProfileChangedEventArgs(INvtSession session, String vsToken, string profToken) {
            this.session = session;
	        this.vsToken = vsToken;
            this.profToken = profToken;
	    }
	    public INvtSession session;
        public String vsToken;
		public string profToken;
    }
    public class ProfileChangedPreviewEvent : PubSubEvent<ProfileChangedEventArgs>{}
	public class ProfileChangedEvent : PubSubEvent<ProfileChangedEventArgs> { }

    public class DeviceEventArgs {
        public DeviceEventArgs(String vsToken, EventDescriptor data) {
            this.vsToken = vsToken;
            this.data = data;
        }
        public String vsToken;
        public EventDescriptor data;
		public MessageContentFilter[] messageContentFilters;
		public TopicExpressionFilter[] topicExpressionFilters;
    }
    public class DeviceEventReceived : PubSubEvent<DeviceEventArgs> { }
    public class DeviceMetadataArgs {
        public DeviceMetadataArgs(String vsToken, XmlDocument xml) {
            this.vsToken = vsToken;
			this.xml = xml;
        }
        public String vsToken;
		public XmlDocument xml;
    }
    public class MetadataEventReceived : PubSubEvent<DeviceMetadataArgs> { }
}
