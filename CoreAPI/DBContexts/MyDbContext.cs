using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CoreAPI.DatabaseModels
{
    /*
    Scaffold-DbContext 
    "Server=###;database=eplocalization;uid=####;pwd=###" 
    Microsoft.EntityFrameworkCore.SqlServer -o 
    DatabaseModels -tables "ClientUser" 
    -contextdir DBContexts -context MyDbContext
    */
    public partial class MyDbContext : DbContext
    {
        public MyDbContext()
        {
        }

        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Clientuser> Clientuser { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
               // optionsBuilder.UseSqlServer("Server=###;database=###;uid=###;pwd=###");
               // MOVED TO Startup.cs
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Clientuser>(entity =>
            {
                entity.HasKey(e => e.Nclientuserid);

                entity.ToTable("clientuser");

                entity.HasIndex(e => e.Caccessgroup)
                    .HasName("clientuser_caccessgroup");

                entity.HasIndex(e => e.Cfname)
                    .HasName("IX_clientuser_3");

                entity.HasIndex(e => e.Clname)
                    .HasName("IX_clientuser_4");

                entity.HasIndex(e => e.Cuserid)
                    .HasName("IX_clientuser_2");

                entity.HasIndex(e => e.Nclientlocationid)
                    .HasName("IX_clientuser_1");

                entity.HasIndex(e => new { e.Cfname, e.Clname, e.Nclientuserid })
                    .HasName("nclientuserid");

                entity.HasIndex(e => new { e.Cuserid, e.Ldenytimecardaprroval, e.Nclientuserid })
                    .HasName("_dta_index_clientuser_7_1796253504__K3_K65_K1");

                entity.HasIndex(e => new { e.Cfname, e.Clname, e.Cemail, e.Nclientuserid })
                    .HasName("_dta_index_clientuser_24_1796253504__K1_5_6_8_32");

                entity.HasIndex(e => new { e.Cfname, e.Clname, e.Nclientuserid, e.Caccessgroup })
                    .HasName("cfname_clname_nclientuserid_caccessgroup");

                entity.HasIndex(e => new { e.Cfname, e.Clname, e.Nclientuserid, e.Nclientlocationid })
                    .HasName("_dta_index_clientuser_78_1796253504__K1_K2_5_6");

                entity.HasIndex(e => new { e.Cemail, e.Nclientuserid, e.Lactive, e.Clname, e.Cfname })
                    .HasName("_dta_index_clientuser_103_1796253504__K1_K23_K6_K5_8");

                entity.HasIndex(e => new { e.Cfname, e.Clname, e.Cemail, e.Ndefaultlanguageid, e.Nclientuserid })
                    .HasName("_dta_index_clientuser_30_1796253504__K1_5_6_8_107");

                entity.HasIndex(e => new { e.Cemail, e.Nclientlocationid, e.Cfname, e.Lactive, e.Clname, e.Nclientuserid })
                    .HasName("_dta_index_clientuser_103_1796253504__K2_K5_K23_K6_K1_8");

                entity.HasIndex(e => new { e.Nclientlocationid, e.Cuserid, e.Cemail, e.Nlevelid, e.Lactive, e.Dcreated, e.Dmodified, e.Ncreatedby, e.Nmodifiedby, e.Cfname, e.Clname, e.Nclientuserid, e.Clevelcode })
                    .HasName("_dta_index_clientuser_37_1796253504__K5_K6_K1_K21_2_3_4_8_20_23_24_25_28_29");

                entity.Property(e => e.Nclientuserid).HasColumnName("nclientuserid");

                entity.Property(e => e.Caccessgroup)
                    .HasColumnName("caccessgroup")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Caddress)
                    .HasColumnName("caddress")
                    .HasMaxLength(100);

                entity.Property(e => e.Caddress2)
                    .HasColumnName("caddress2")
                    .HasMaxLength(100);

                entity.Property(e => e.Ccity)
                    .HasColumnName("ccity")
                    .HasMaxLength(50);

                entity.Property(e => e.Ccountry)
                    .HasColumnName("ccountry")
                    .HasMaxLength(50);

                entity.Property(e => e.Cemail)
                    .HasColumnName("cemail")
                    .HasMaxLength(100);

                entity.Property(e => e.Cesignature)
                    .HasColumnName("cesignature")
                    .HasMaxLength(100);

                entity.Property(e => e.Cfax)
                    .HasColumnName("cfax")
                    .HasMaxLength(50);

                entity.Property(e => e.Cfname)
                    .HasColumnName("cfname")
                    .HasMaxLength(50);

                entity.Property(e => e.Clevelcode)
                    .HasColumnName("clevelcode")
                    .HasMaxLength(50);

                entity.Property(e => e.Clname)
                    .HasColumnName("clname")
                    .HasMaxLength(50);

                entity.Property(e => e.Coldpassword1).HasColumnName("coldpassword1");

                entity.Property(e => e.Coldpassword2).HasColumnName("coldpassword2");

                entity.Property(e => e.Coldpassword3).HasColumnName("coldpassword3");

                entity.Property(e => e.Coldpassword4).HasColumnName("coldpassword4");

                entity.Property(e => e.Coldpassword5).HasColumnName("coldpassword5");

                entity.Property(e => e.Corganizationcode)
                    .HasColumnName("corganizationcode")
                    .HasMaxLength(50);

                entity.Property(e => e.Cpagetheme)
                    .HasColumnName("cpagetheme")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Cpassword).HasColumnName("cpassword");

                entity.Property(e => e.Cpasswordtype)
                    .HasColumnName("cpasswordtype")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('BCrypt')");

                entity.Property(e => e.Csbstring)
                    .HasColumnName("csbstring")
                    .HasMaxLength(100);

                entity.Property(e => e.Cssouserid)
                    .HasColumnName("cssouserid")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Cstate)
                    .HasColumnName("cstate")
                    .HasMaxLength(50);

                entity.Property(e => e.Ctel)
                    .HasColumnName("ctel")
                    .HasMaxLength(50);

                entity.Property(e => e.Ctelext)
                    .HasColumnName("ctelext")
                    .HasMaxLength(50);

                entity.Property(e => e.Ctitle)
                    .HasColumnName("ctitle")
                    .HasMaxLength(50);

                entity.Property(e => e.Cttdnumber)
                    .HasColumnName("cttdnumber")
                    .HasMaxLength(50);

                entity.Property(e => e.Curl)
                    .HasColumnName("curl")
                    .HasMaxLength(100);

                entity.Property(e => e.Cuserid)
                    .HasColumnName("cuserid")
                    .HasMaxLength(50);

                entity.Property(e => e.Czipcode)
                    .HasColumnName("czipcode")
                    .HasMaxLength(20);

                entity.Property(e => e.Daccepttermsconditions)
                    .HasColumnName("daccepttermsconditions")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dcreated)
                    .HasColumnName("dcreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Dgetemail1)
                    .HasColumnName("dgetemail1")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dgetemail2)
                    .HasColumnName("dgetemail2")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dgetemail3)
                    .HasColumnName("dgetemail3")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dlastpasswordupdate)
                    .HasColumnName("dlastpasswordupdate")
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Dlasttimelogin)
                    .HasColumnName("dlasttimelogin")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dlocked)
                    .HasColumnName("dlocked")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dmodified)
                    .HasColumnName("dmodified")
                    .HasColumnType("datetime");

                entity.Property(e => e.Lactive)
                    .HasColumnName("lactive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Lallowmodifyjobinfo)
                    .HasColumnName("lallowmodifyjobinfo")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Lallowzerobillreq)
                    .HasColumnName("lallowzerobillreq")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Lapproveinsidetimecard)
                    .HasColumnName("lapproveinsidetimecard")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Lbillcontact)
                    .HasColumnName("lbillcontact")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Lblockemailfromvendor)
                    .HasColumnName("lblockemailfromvendor")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Lblocksystememail)
                    .HasColumnName("lblocksystememail")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Lchangeapproval)
                    .HasColumnName("lchangeapproval")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LchangeapprovalProject)
                    .HasColumnName("lchangeapproval_project")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Lclientadmin)
                    .HasColumnName("lclientadmin")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Lcontractadditionaluser).HasColumnName("lcontractadditionaluser");

                entity.Property(e => e.Ldenytimecardaprroval)
                    .HasColumnName("ldenytimecardaprroval")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Ldisableassignmentadditionalexpense)
                    .HasColumnName("ldisableassignmentadditionalexpense")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Ldisableassignmentextension).HasColumnName("ldisableassignmentextension");

                entity.Property(e => e.Ldisableassignmentratechange).HasColumnName("ldisableassignmentratechange");

                entity.Property(e => e.Ldisablebillrate)
                    .HasColumnName("ldisablebillrate")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Ldisablemarkup)
                    .HasColumnName("ldisablemarkup")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Ldisablemodifyassignmentproxy).HasColumnName("ldisablemodifyassignmentproxy");

                entity.Property(e => e.Ldisablemodifyjobproxy).HasColumnName("ldisablemodifyjobproxy");

                entity.Property(e => e.Ldisablemodifysbprofile)
                    .HasColumnName("ldisablemodifysbprofile")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Ldisablemodifytcproxy).HasColumnName("ldisablemodifytcproxy");

                entity.Property(e => e.Ldisablepayrate)
                    .HasColumnName("ldisablepayrate")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Ldisablepreferbillrate)
                    .HasColumnName("ldisablepreferbillrate")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Ldisablespecialbill)
                    .HasColumnName("ldisablespecialbill")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Ldisableworkdaysrequest)
                    .HasColumnName("ldisableworkdaysrequest")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Ldisplayallvendorlocation)
                    .HasColumnName("ldisplayallvendorlocation")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LdisplayallvendorlocationProject).HasColumnName("ldisplayallvendorlocation_project");

                entity.Property(e => e.Lemailperschedule)
                    .HasColumnName("lemailperschedule")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Lenablecreateproject).HasColumnName("lenablecreateproject");

                entity.Property(e => e.Lenablecreatesow).HasColumnName("lenablecreatesow");

                entity.Property(e => e.Lenableskilljobtitlesearch)
                    .HasColumnName("lenableskilljobtitlesearch")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Lfirsttimelogin)
                    .HasColumnName("lfirsttimelogin")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Lhideassgadditionaltimecardspend)
                    .HasColumnName("lhideassgadditionaltimecardspend")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Lhideassgbill)
                    .HasColumnName("lhideassgbill")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Lhideassgestimate)
                    .HasColumnName("lhideassgestimate")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Lhideassgexpense)
                    .HasColumnName("lhideassgexpense")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Lhideassginclusive)
                    .HasColumnName("lhideassginclusive")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Lhideassgpay)
                    .HasColumnName("lhideassgpay")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Lhidebillrate)
                    .HasColumnName("lhidebillrate")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Lhideduplicatejob).HasColumnName("lhideduplicatejob");

                entity.Property(e => e.Lhidejobadditionaltimecardspend)
                    .HasColumnName("lhidejobadditionaltimecardspend")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Lhidejobestimate)
                    .HasColumnName("lhidejobestimate")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Lhidejobexempt)
                    .HasColumnName("lhidejobexempt")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Lhidejobexpense)
                    .HasColumnName("lhidejobexpense")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Lhidemarkup)
                    .HasColumnName("lhidemarkup")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Lhidenegotiaterate)
                    .HasColumnName("lhidenegotiaterate")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Lhidepayrate)
                    .HasColumnName("lhidepayrate")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Lhidepreferbillrate)
                    .HasColumnName("lhidepreferbillrate")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Lhidereplacement)
                    .HasColumnName("lhidereplacement")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Lhideresubmitorder)
                    .HasColumnName("lhideresubmitorder")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Lhidevendornamehiringproccess)
                    .HasColumnName("lhidevendornamehiringproccess")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Liccapprovaluser).HasColumnName("liccapprovaluser");

                entity.Property(e => e.Llocked)
                    .HasColumnName("llocked")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Lnotallowcreatejob)
                    .HasColumnName("lnotallowcreatejob")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Lnotallowmodifyexpense)
                    .HasColumnName("lnotallowmodifyexpense")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Lnotallowmodifytimecard)
                    .HasColumnName("lnotallowmodifytimecard")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Lonepagereqcreation).HasColumnName("lonepagereqcreation");

                entity.Property(e => e.Lonepagereqcreationnobill)
                    .HasColumnName("lonepagereqcreationnobill")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Lopenbidadmin).HasColumnName("lopenbidadmin");

                entity.Property(e => e.Lpopupmessage)
                    .HasColumnName("lpopupmessage")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Lreportbasedonhirearchy)
                    .HasColumnName("lreportbasedonhirearchy")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Lreportscheduling)
                    .HasColumnName("lreportscheduling")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Lreqapprovalbymobile)
                    .HasColumnName("lreqapprovalbymobile")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Lselfregister)
                    .HasColumnName("lselfregister")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Lshowassignmentudf)
                    .HasColumnName("lshowassignmentudf")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Lshowclassificationrecommendation).HasColumnName("lshowclassificationrecommendation");

                entity.Property(e => e.LshowclassificationrecommendationNonbill).HasColumnName("lshowclassificationrecommendation_nonbill");

                entity.Property(e => e.LshowclassificationrecommendationProject).HasColumnName("lshowclassificationrecommendation_project");

                entity.Property(e => e.LshowclassificationrecommendationSow).HasColumnName("lshowclassificationrecommendation_sow");

                entity.Property(e => e.Lshowclientcandidatewizard)
                    .HasColumnName("lshowclientcandidatewizard")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Lshowjobtitleadvancesearch)
                    .HasColumnName("lshowjobtitleadvancesearch")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Lsso)
                    .HasColumnName("lsso")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Lvendorlisting).HasColumnName("lvendorlisting");

                entity.Property(e => e.Lworklocationcode)
                    .HasColumnName("lworklocationcode")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Napprovalmethod)
                    .HasColumnName("napprovalmethod")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Nbillcontactid).HasColumnName("nbillcontactid");

                entity.Property(e => e.Nclientlocationid).HasColumnName("nclientlocationid");

                entity.Property(e => e.Ncreatedby).HasColumnName("ncreatedby");

                entity.Property(e => e.Ncreatedbywho).HasColumnName("ncreatedbywho");

                entity.Property(e => e.Ndefaultlanguageid)
                    .HasColumnName("ndefaultlanguageid")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Ndefaulttimezoneid).HasColumnName("ndefaulttimezoneid");

                entity.Property(e => e.Ndirectsend).HasColumnName("ndirectsend");

                entity.Property(e => e.Ndirectsendproject).HasColumnName("ndirectsendproject");

                entity.Property(e => e.Nhierarchyreporttoid).HasColumnName("nhierarchyreporttoid");

                entity.Property(e => e.Nlevelid)
                    .HasColumnName("nlevelid")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Nmodifiedby).HasColumnName("nmodifiedby");

                entity.Property(e => e.Nmodifiedbywho).HasColumnName("nmodifiedbywho");

                entity.Property(e => e.Npasswordattempt).HasColumnName("npasswordattempt");

                entity.Property(e => e.Ntimecardapprovaltype)
                    .HasColumnName("ntimecardapprovaltype")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Nvendorselectoption)
                    .HasColumnName("nvendorselectoption")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.NvendorselectoptionProject)
                    .HasColumnName("nvendorselectoption_project")
                    .HasDefaultValueSql("((0))");
            });
        }
    }
}
